using Happy5SocialMedia.Common.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Message.Application.DTO
{
    public class ListMessagesResponse
    {
        public string Title { get; set; }
        public string ContentMessage { get; set; }
        public AccountUserDto Sender{ get; set; }
        public AccountUserDto Reciever { get; set; }
        public string StatusConversation { get; set; }
        public string StatusMessage{ get; set; }
        public string Status { get; set; }
    }
}
