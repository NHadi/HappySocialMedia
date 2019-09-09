using Happy5SocialMedia.Common.API.DTO;
using Happy5SocialMedia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Services.Interface
{
    public interface IUserService
    {
        ApiDto Add(AccountUserCreateRequest request);
        ApiDto Update(Guid IdUser, AccountUserUpdateRequest request);
        ApiDto ListUser();
        ApiDto ListSubordinates(Guid IdUser);
        ApiDto ListParents(Guid IdUser);
    }
}
