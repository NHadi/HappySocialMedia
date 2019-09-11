using AutoMapper;
using Happy5SocialMedia.Activity.Application.DTO;
using Happy5SocialMedia.Activity.Domain.Model;
using Happy5SocialMedia.Activity.Domain.Model.Repositories.Interface;
using Happy5SocialMedia.Activity.Domain.Services;
using Happy5SocialMedia.Activity.Infrastructure.Repositories.Extensions;
using Happy5SocialMedia.Common;
using Happy5SocialMedia.Common.API.DTO;
using Happy5SocialMedia.Common.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Happy5SocialMedia.Activity.Application
{
    public class FriendService : IFriendService
    {        
        private readonly IMapper _mapper;
        private readonly IActivityStatusRepository _activityStatusRepository;
        private readonly IFriendRelationshipRepository _friendRelationshipRepository;
        private readonly IFriendRequestRepository _friendRequestRepository;
        private readonly IUserApiService _userApiService;
        public FriendService(IMapper mapper,
            IActivityStatusRepository activityStatusRepository,
            IFriendRelationshipRepository friendRelationshipRepository,
            IFriendRequestRepository friendRequestRepository,
            IUserApiService userApiService
            )
        {
            _mapper = mapper;
            _activityStatusRepository = activityStatusRepository;
            _friendRelationshipRepository = friendRelationshipRepository;
            _friendRequestRepository = friendRequestRepository;
            _userApiService = userApiService;
        }

        public (bool status, string message) Approve(Guid idRequest)
        {
            try
            {
                bool _status = true;
                string _message = "Success";

                _friendRequestRepository.BeginTransaction();

                var approveRequest = _friendRequestRepository.GetInclude(x => x.Id == idRequest,
                        includes: source => source.Include(x => x.FriendRelationship)
                    ).SingleOrDefault();

                if(approveRequest != null)
                {
                    approveRequest.Status = _activityStatusRepository.Get(x => x.Name.Equals(Global.Status.Accepted)).FirstOrDefault().Id;
                    _friendRequestRepository.Update(approveRequest);

                    var relationship = approveRequest.FriendRelationship.FirstOrDefault();
                    relationship.Status = _activityStatusRepository.Get(x => x.Name.Equals(Global.Status.Accepted)).FirstOrDefault().Id;
                    _friendRelationshipRepository.Update(relationship);

                    _friendRequestRepository.Save();
                }
                else
                {
                    _status = false;
                    _message = "Request not found";
                }
                
                _friendRequestRepository.CommitTransaction();

                return (_status, _message);
            }
            catch (Exception ex)
            {
                _friendRequestRepository.RollbackTransaction();
                throw ex;
            }
        }

        public List<AccountUserDto> ListFriend(Guid idAccountUser)
        {
            try
            {
                var friendRequests = _friendRequestRepository.GetInclude(x => x.UserReciever == idAccountUser || x.UserSender == idAccountUser,
                        includes: sources =>
                            sources.Include(x => x.StatusNavigation)
                                .Include(x => x.FriendRelationship)
                                    .ThenInclude(y => y.StatusNavigation)
                            ).FilterRelationship()
                        .ToList();                

                var userFriend = friendRequests.Select(x => x.UserSender)
                    .Union(friendRequests.Select(x => x.UserReciever))
                    .Where(x => !x.Equals(idAccountUser))
                    .ToList();                    

                var userRequest = _userApiService.GetUsers(userFriend);

                return userRequest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountUserDto> ListFriendRequest(Guid idAccountUser)
        {
            try
            {
                var friendRequests = _friendRequestRepository.GetInclude(x => x.UserReciever == idAccountUser,
                        includes: sources =>
                            sources.Include(x => x.StatusNavigation)
                                .Include(x => x.FriendRelationship)
                                    .ThenInclude(y => y.StatusNavigation)
                        ).FilterRequest()
                    .ToList();
                
                var allUserSendRequest = friendRequests.Select(x => x.UserSender).ToList();

                var userRequest = _userApiService.GetUsers(allUserSendRequest);

                return userRequest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListFriendRequest> ListRequest()
        {
            try
            {
                var result = new List<ListFriendRequest>();
               
                var listRequest = _friendRequestRepository
                    .GetInclude(includes: sources => sources.Include(x => x.StatusNavigation)).ToList();

                listRequest.ForEach(item =>
                {
                    var tmp = new ListFriendRequest
                    {
                        IdRequest = item.Id,
                        UserSender = _userApiService.Detail(item.UserSender),
                        UserReciever = _userApiService.Detail(item.UserReciever),
                        Status = item.StatusNavigation.Name,                        
                    };

                    result.Add(tmp);
                });


                return result;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public (bool status, string message) Request(Guid userSender, Guid userReciever)
        {
            try
            {
                bool _status = true;
                string _message = "Success";

                _friendRequestRepository.BeginTransaction();

                if (_userApiService.UserExist(userSender) == true && _userApiService.UserExist(userReciever) == true)
                {
                    var request = new FriendRequest
                    {
                        Id = Guid.NewGuid(),
                        UserSender = userSender,
                        UserReciever = userReciever,
                        Status = _activityStatusRepository.Get(x => x.Name.Equals(Global.Status.Request)).FirstOrDefault().Id
                    };                    

                    _friendRequestRepository.Insert(request);

                    var relationship = new FriendRelationship
                    {
                        Id = Guid.NewGuid(),
                        FriendRequestId = request.Id,
                        Status = _activityStatusRepository.Get(x => x.Name.Equals(Global.Status.Pending)).FirstOrDefault().Id
                    };

                    _friendRelationshipRepository.Insert(relationship);

                    _friendRequestRepository.Save();
                }
                else
                {
                    _status = false;
                    _message = "User Sender or Reciever not exist";
                }

                _friendRequestRepository.CommitTransaction();

                return (_status, _message);

            }
            catch (Exception ex)
            {
                _friendRequestRepository.RollbackTransaction();
                throw ex;
            }
        }
    }
}
