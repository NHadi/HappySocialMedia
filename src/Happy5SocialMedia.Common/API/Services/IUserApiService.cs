using Happy5SocialMedia.Common.API.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common.API.Services
{
    public interface IUserApiService
    {
        AccountUserDto Detail(Guid IdUser);
        List<AccountUserDto> GetUsers(List<Guid> IdUser);
        bool UserExist(Guid IdUser);
    }
}
