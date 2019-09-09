using System;
using System.Collections.Generic;

namespace Happy5SocialMedia.Activity.Domain.Model
{
    public partial class FriendRelationship
    {
        public Guid Id { get; set; }
        public Guid FriendRequestId { get; set; }
        public Guid Status { get; set; }

        public virtual FriendRequest FriendRequest { get; set; }
        public virtual ActivityStatus StatusNavigation { get; set; }
    }
}