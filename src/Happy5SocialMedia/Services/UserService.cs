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

        public ApiDto Add(AccountUserCreateRequest accountUser)
        => new HTTPWebRequestUtilities<ApiDto>(_urlApiFactory.GetUrl(ServiceType.User))
                            .Request(Global.Method.POST, $"User", accountUser);

        public ApiDto Delete(Guid Id)
        => new HTTPWebRequestUtilities<ApiDto>(_urlApiFactory.GetUrl(ServiceType.User))
                            .Request(Global.Method.DELETE, $"User/{Id}");

        public AccountUserRespond Detail(Guid Id)
        => new HTTPWebRequestUtilities<AccountUserRespond>(_urlApiFactory.GetUrl(ServiceType.User))
                            .GetSingle($"User/{Id}");

        public List<AccountUserRespond> ListParents(Guid IdAccountUser)
        => new HTTPWebRequestUtilities<AccountUserRespond>(_urlApiFactory.GetUrl(ServiceType.User))
                            .Get($"User/{IdAccountUser}/Parent").ToList();

        public List<AccountUserRespond> ListSubordinates(Guid IdAccountUser)
        => new HTTPWebRequestUtilities<AccountUserRespond>(_urlApiFactory.GetUrl(ServiceType.User))
                            .Get($"User/{IdAccountUser}/subordinates").ToList();

        public List<AccountUserRespond> ListUser(string keyword)
        => new HTTPWebRequestUtilities<AccountUserRespond>(_urlApiFactory.GetUrl(ServiceType.User))
                            .Get($"User/{keyword}").ToList();

        public List<AccountUserRespond> ListUser()
        => new HTTPWebRequestUtilities<AccountUserRespond>(_urlApiFactory.GetUrl(ServiceType.User))
                            .Get($"User").ToList();

        public List<AccountUserRespond> ListUser(List<Guid> IdAccountUsers)
            => new HTTPWebRequestUtilities<AccountUserRespond>(_urlApiFactory.GetUrl(ServiceType.User))
                            .Post($"Users", IdAccountUsers);
           
        public ApiDto Update(Guid Id, AccountUserUpdateRequest request)
            =>  new HTTPWebRequestUtilities<ApiDto>(_urlApiFactory.GetUrl(ServiceType.User))
                           .Request(Global.Method.PUT, $"User/{Id}", request);

    }
}
