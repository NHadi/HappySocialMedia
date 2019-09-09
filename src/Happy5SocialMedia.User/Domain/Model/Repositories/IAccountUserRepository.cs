using Happy5SocialMedia.Common.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.User.Domain.Model.Repositories
{
    public interface IAccountUserRepository : IEfRepository<AccountUser>
    {
        IEnumerable<AccountUser> ListUsers(string keyword);
        IEnumerable<AccountUser> ListParents(Guid IdAccountUser);
        IEnumerable<AccountUser> ListSubordinates(Guid IdAccountUser);
    }
}
