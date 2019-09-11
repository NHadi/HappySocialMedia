using Happy5SocialMedia.Common.API.DTO;
using Happy5SocialMedia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Services.Interface
{
    public interface IMessageService
    {
        ApiDto SendMessage(SendMessageRequest request);
        List<AccountUserDto> ListUserConversation(Guid idUser);
        List<ListMessagesResponse> ListMessage(Guid idConversation);
    }
}
