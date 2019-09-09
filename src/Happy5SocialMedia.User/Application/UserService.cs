using AutoMapper;
using Happy5SocialMedia.User.Application.DTO;
using Happy5SocialMedia.User.Domain.Model;
using Happy5SocialMedia.User.Domain.Model.Repositories;
using Happy5SocialMedia.User.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Happy5SocialMedia.User.Application
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IAccountUserRepository _accountUserRepository;
        public UserService(IMapper mapper, IAccountUserRepository accountUserRepository)
        {
            _mapper = mapper;
            _accountUserRepository = accountUserRepository;
        }

        public void Add(AccountUserCreateRequest request)
        {
            try
            {
                _accountUserRepository.BeginTransaction();

                var dataInserted = _mapper.Map<AccountUser>(request);
                _accountUserRepository.Insert(dataInserted);
                _accountUserRepository.Save();
                _accountUserRepository.CommitTransaction();
            }
            catch (Exception ex)
            {
                //logHere
                _accountUserRepository.RollbackTransaction();
                throw ex;
            }
        }

        public void Delete(Guid Id)
        {
            try
            {
                _accountUserRepository.BeginTransaction();
                var data = _accountUserRepository.Get(x => x.Id == Id).SingleOrDefault();

                _accountUserRepository.Delete(data);

                _accountUserRepository.Save();
                _accountUserRepository.CommitTransaction();
            }
            catch (Exception ex)
            {
                _accountUserRepository.RollbackTransaction();
                throw ex;
            }
        }

        public AccountUserRespond Detail(Guid Id)
        {
            try
            {
                var data = _accountUserRepository.Get(x => x.Id == Id).SingleOrDefault();
                var result = _mapper.Map<AccountUserRespond>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<AccountUserRespond> ListParents(Guid IdAccountUser)
        {
            
            try
            {
                var data = _accountUserRepository.ListParents(IdAccountUser).ToList();
                var result = _mapper.Map<List<AccountUserRespond>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountUserRespond> ListSubordinates(Guid IdAccountUser)
        {
            try
            {
                var data = _accountUserRepository.ListSubordinates(IdAccountUser).ToList();
                var result = _mapper.Map<List<AccountUserRespond>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountUserRespond> ListUser(string keyword)
        {
            try
            {
                var data = _accountUserRepository.ListUsers(keyword).ToList();
                var result = _mapper.Map<List<AccountUserRespond>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountUserRespond> ListUser()
        {
            try
            {
                var data = _accountUserRepository.Get().ToList();                
                var result = _mapper.Map<List<AccountUserRespond>>(data);
                result.ForEach(item =>
                {
                    item.Parents = _mapper.Map<List<AccountUserRespond>>(ListParents(item.Id));
                    item.Subordinates = _mapper.Map<List<AccountUserRespond>>(ListSubordinates(item.Id));
                });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountUserRespond> ListUser(List<Guid> IdAccountUsers)
            => _mapper.Map<List<AccountUserRespond>>(_accountUserRepository.Get(x => IdAccountUsers.Contains(x.Id)).ToList());

        public void Update(Guid Id, AccountUserUpdateRequest accountUser)
        {
            try
            {
                _accountUserRepository.BeginTransaction();

                var data = _accountUserRepository.Get(x => x.Id == Id, false).SingleOrDefault();
                if (data != null)
                {
                    var dataUpdated = _mapper.Map<AccountUser>(accountUser);
                    dataUpdated.Id = data.Id;

                    _accountUserRepository.Update(dataUpdated);
                }

                _accountUserRepository.Save();
                _accountUserRepository.CommitTransaction();
            }
            catch (Exception ex)
            {
                _accountUserRepository.RollbackTransaction();
                throw ex;
            }
        }

        public bool UserExist(Guid Id)
        {
            try
            {                
                var exist = Detail(Id) != null ? true : false;
                return exist;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
