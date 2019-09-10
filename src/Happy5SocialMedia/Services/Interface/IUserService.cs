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
        ApiDto Add(AccountUserCreateRequest accountUser);
        ApiDto Update(Guid Id, AccountUserUpdateRequest accountUser);
        ApiDto Delete(Guid Id);
        AccountUserRespond Detail(Guid Id);
        List<AccountUserRespond> ListUser(string keyword);
        List<AccountUserRespond> ListUser();
        List<AccountUserRespond> ListUser(List<Guid> IdAccountUsers);
        List<AccountUserRespond> ListSubordinates(Guid IdAccountUser);
        List<AccountUserRespond> ListParents(Guid IdAccountUser);
    }
}
