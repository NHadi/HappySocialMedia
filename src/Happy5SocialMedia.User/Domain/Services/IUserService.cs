using Happy5SocialMedia.User.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.User.Domain.Services
{
    public interface IUserService
    {
        void Add(AccountUserCreateRequest accountUser);
        void Update(Guid Id, AccountUserUpdateRequest accountUser);
        void Delete(Guid Id);
        bool UserExist(Guid Id);
        AccountUserRespond Detail(Guid Id);
        List<AccountUserRespond> ListUser(string keyword);
        List<AccountUserRespond> ListUser();
        List<AccountUserRespond> ListUser(List<Guid> IdAccountUsers);
        List<AccountUserRespond> ListSubordinates(Guid IdAccountUser);
        List<AccountUserRespond> ListParents(Guid IdAccountUser);
    }
}
