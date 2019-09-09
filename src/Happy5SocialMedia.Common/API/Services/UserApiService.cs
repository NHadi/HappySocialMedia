using AutoMapper;
using Happy5SocialMedia.Common.API.DTO;
using Happy5SocialMedia.Common.API.Enum;
using Happy5SocialMedia.Common.API.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common.API.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly IUrlApiFactory _urlApiFactory;
        private readonly IMapper _mapper;
        public UserApiService(IUrlApiFactory urlApiFactory, IMapper mapper)
        {
            _urlApiFactory = urlApiFactory;
            _mapper = mapper;
        }

        public AccountUserDto Detail(Guid IdUser)
        {
            try
            {
                var resspond = new HTTPWebRequestUtilities<AccountUserDto>(_urlApiFactory.GetUrl(ServiceType.User))
                            .GetSingle($"User/{IdUser}");

                return resspond;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountUserDto> GetUsers(List<Guid> IdUser)
        {
            try
            {
                var data = new HTTPWebRequestUtilities<AccountUserDto>(_urlApiFactory.GetUrl(ServiceType.User))
                             .Post($"Users", IdUser);

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UserExist(Guid IdUser)
        {
            try
            {
                var exist = new HTTPWebRequestUtilities<AccountUserDto>(_urlApiFactory.GetUrl(ServiceType.User))
                             .GetSingle($"User/{IdUser}");

                return exist != null ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
