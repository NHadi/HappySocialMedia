using Happy5SocialMedia.Common.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Activity.Domain.Model.Repositories.Interface
{
    public interface IFriendRequestRepository  :IEfRepository<FriendRequest>
    {
        bool HasRelated(Guid UserSender, Guid UserReciever);
    }
}
