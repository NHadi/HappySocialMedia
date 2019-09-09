using Happy5SocialMedia.Common.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Activity.Application.DTO
{
    public class ListFriendRequest
    {
        public AccountUserDto UserSender { get; set; }
        public AccountUserDto UserReciever { get; set; }
        public string Status { get; set; }
    }
}
