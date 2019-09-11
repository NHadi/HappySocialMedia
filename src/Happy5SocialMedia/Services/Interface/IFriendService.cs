using Happy5SocialMedia.Common.API.DTO;
using Happy5SocialMedia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Services.Interface
{
    public interface IFriendService
    {
        ApiDto Approve(Guid idRequest);
        ApiDto Request(FriendRelationshipRequest request);
        List<AccountUserDto> ListFriendRequest(Guid idAccountUser);
        List<ListFriendRequest> ListRequest();
        List<AccountUserDto> ListFriend(Guid idAccountUser);

    }
}
