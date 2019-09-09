using AutoMapper;
using Happy5SocialMedia.Common;
using Happy5SocialMedia.Common.Securities;
using Happy5SocialMedia.User.Application.DTO;
using Happy5SocialMedia.User.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.User
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountUser, AccountUserRespond>();
            CreateMap<AccountUserRequest, AccountUser>();

            CreateMap<AccountUserCreateRequest, AccountUser>()
                .ForMember(x => x.Id, o => o.MapFrom(s => Guid.NewGuid()))                  
                .ForMember(x => x.Password, o => o.MapFrom(s => Encryptor.Encrypt(s.Password, Global.Key.EncryptDecrypt)));  
            
            CreateMap<AccountUserUpdateRequest, AccountUser>();
        }
    }
}
