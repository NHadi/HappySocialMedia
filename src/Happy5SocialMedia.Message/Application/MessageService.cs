using AutoMapper;
using Happy5SocialMedia.Common;
using Happy5SocialMedia.Common.API.DTO;
using Happy5SocialMedia.Common.API.Services;
using Happy5SocialMedia.Message.Application.DTO;
using Happy5SocialMedia.Message.Domain.Model;
using Happy5SocialMedia.Message.Domain.Model.Repositories.Interface;
using Happy5SocialMedia.Message.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Happy5SocialMedia.Message.Application
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IActivityStatusRepository _activityStatusRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IUserApiService _userApiService;
        public MessageService(IMapper mapper,
            IActivityStatusRepository activityStatusRepository,
            IUserApiService userApiService,
            IMessageRepository messageRepository,
            IConversationRepository conversationRepository,
            IParticipantRepository participantRepository
            )
        {
            _mapper = mapper;
            _activityStatusRepository = activityStatusRepository;
            _userApiService = userApiService;
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
            _participantRepository = participantRepository;
        }

        public List<ListMessagesResponse> ListMessage(Guid idConversation)
        {
            try
            {
                var result = new List<ListMessagesResponse>();

                var dataConversation = _conversationRepository.GetInclude(x => x.Id == idConversation,
                            includes:
                                source =>
                                    source.Include(x => x.Participant)
                                        .ThenInclude(y => y.StatusNavigation)
                                        .Include(x => x.Messages)
                                        .ThenInclude(y => y.StatusNavigation)
                        ).FirstOrDefault();

                if (dataConversation != null)
                {

                    var userSender = dataConversation.Messages                       
                        .Select(x => x.Conversation.UserCreator);

                    var userReciever = dataConversation.Messages
                        .Select(x => x.Participant.UserAccount);

                    var allUserConvensation = _userApiService.GetUsers(userSender.Union(userReciever).Distinct().ToList());

                    dataConversation.Messages.ToList().ForEach(item =>
                    {
                        var tmp = new ListMessagesResponse
                        {
                            Title = item.Conversation.Title,
                            ContentMessage = item.ContentMessage,
                            Sender = allUserConvensation.Where(x => x.Id == item.Conversation.UserCreator).FirstOrDefault(),
                            Reciever = allUserConvensation.Where(x => x.Id == item.Participant.UserAccount).FirstOrDefault(),
                            StatusConversation = item.Conversation.IsActive == true ? "Open" : "Closed",
                            StatusMessage = item.StatusNavigation.Name,
                            Status = item.Participant.StatusNavigation.Name
                        };

                        result.Add(tmp);
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountUserDto> ListUserConversation(Guid idUser)
        {
            try
            {
                var result = new List<AccountUserDto>();

                if (_userApiService.UserExist(idUser) == true)
                {
                    var dataConversation = _conversationRepository.GetInclude(x => x.UserCreator == idUser && x.IsActive == true, 
                            includes: 
                                source => 
                                    source.Include(x => x.Participant)
                                    .Include(x => x.Messages)
                        ).ToList();

                    var readMessages = dataConversation.SelectMany(x => x.Participant).ToList();
                    readMessages.ForEach(item =>
                    {
                        item.Status = _activityStatusRepository.Get(x => x.Name.Equals(Global.Status.Read)).FirstOrDefault().Id;
                    });

                    _participantRepository.UpdateRange(readMessages);
                    _participantRepository.Save();

                    var userConversation = dataConversation
                        .SelectMany(x => x.Participant)
                        .Select(x => x.UserAccount)
                        .ToList();

                    result = _userApiService.GetUsers(userConversation);
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public (bool status, string message) SendMessage(SendMessageRequest request)
        {
            try
            {
                bool _status = true;
                string _message = "Success";

                _messageRepository.BeginTransaction();

                if (_userApiService.UserExist(request.UserSender) == true && _userApiService.UserExist(request.UserReciever) == true)
                {
                    var conversation = new Conversation
                    {
                        Id = Guid.NewGuid(),
                        IsActive = true,
                        UserCreator = request.UserSender,
                        Title = request.Title
                    };

                    _conversationRepository.Insert(conversation);
                    _conversationRepository.Save();

                    var participant =  new Participant()
                    {
                        Id = Guid.NewGuid(),
                        Conversation = conversation,
                        Status = _activityStatusRepository.Get(x => x.Name.Equals(Global.Status.UnRead)).FirstOrDefault().Id,
                        UserAccount = request.UserReciever
                    };

                    _participantRepository.Insert(participant);
                    _participantRepository.Save();

                    var message = new Messages
                    {
                        Id = Guid.NewGuid(),
                        ContentMessage = request.ContentMessage,
                        ParticipantId = participant.Id,
                        ConversationId = conversation.Id,
                        Status = _activityStatusRepository.Get(x => x.Name.Equals(Global.Status.Delivered)).FirstOrDefault().Id
                    };

                    _messageRepository.Insert(message);
                    _messageRepository.Save();
                }
                else
                {
                    _status = false;
                    _message = "User Sender or Reciever not exist";
                }

                _messageRepository.CommitTransaction();

                return (_status, _message);
            }
            catch (Exception ex)
            {
                _messageRepository.RollbackTransaction();
                throw ex;
            }
        }
    }
}
