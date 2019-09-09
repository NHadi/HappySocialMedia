using AutoMapper;
using Happy5SocialMedia.Common;
using Happy5SocialMedia.Common.API;
using Happy5SocialMedia.Common.API.DTO;
using Happy5SocialMedia.Common.API.Enum;
using Happy5SocialMedia.Common.API.Interface;
using Happy5SocialMedia.DTO;
using Happy5SocialMedia.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Services
{
    public class UserService : IUserService
    {
        private readonly IUrlApiFactory _urlApiFactory;
        private readonly IMapper _mapper;
        public UserService(IUrlApiFactory urlApiFactory, IMapper mapper)
        {
            _urlApiFactory = urlApiFactory;
            _mapper = mapper;
        }

        public ApiDto Add(AccountUserCreateRequest request)
        {
            try
            {
                var resspond = new HTTPWebRequestUtilities<ApiDto>(_urlApiFactory.GetUrl(ServiceType.User))
                           .PostSingle("User", request);

                return resspond;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApiDto ListParents(Guid IdUser)
        {
            var resspond = new HTTPWebRequestUtilities<ApiDto>(_urlApiFactory.GetUrl(ServiceType.User))
                           .GetSingle($"User/{IdUser}");

            return resspond;
        }

        public ApiDto ListSubordinates(Guid IdUser)
        {
            var resspond = new HTTPWebRequestUtilities<ApiDto>(_urlApiFactory.GetUrl(ServiceType.User))
                           .GetSingle($"User/{IdUser}/subordinates");

            return resspond;
        }

        public ApiDto ListUser()
        {
            var resspond = new HTTPWebRequestUtilities<ApiDto>(_urlApiFactory.GetUrl(ServiceType.User))
                           .Request(Global.Method.GET, $"User");

            return resspond;
        }

        public ApiDto Update(Guid IdUser, AccountUserUpdateRequest request)
        {
            var resspond = new HTTPWebRequestUtilities<ApiDto>(_urlApiFactory.GetUrl(ServiceType.User))
                           .Request(Global.Method.PUT, $"User/{IdUser}", request);

            return resspond;
        }
    }
}
