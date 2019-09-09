using Happy5SocialMedia.Common.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Message.Domain.Model.Repositories.Interface
{
    public interface IConversationRepository : IEfRepository<Conversation>
    {
    }
}
