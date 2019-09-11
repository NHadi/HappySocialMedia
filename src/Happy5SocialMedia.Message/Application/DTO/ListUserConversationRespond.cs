using Happy5SocialMedia.Common.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Message.Application.DTO
{
    public class ListUserConversationRespond
    {
        public ListUserConversationRespond()
        {
            Users = new List<AccountUserDto>();
        }
        public Guid IdConversation { get; set; }
        public List<AccountUserDto> Users{ get; set; }
    }
}
