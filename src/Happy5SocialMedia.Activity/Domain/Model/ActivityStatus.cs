using System;
using System.Collections.Generic;

namespace Happy5SocialMedia.Activity.Domain.Model
{
    public partial class ActivityStatus
    {
        public ActivityStatus()
        {
            FriendRelationship = new HashSet<FriendRelationship>();
            FriendRequest = new HashSet<FriendRequest>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FriendRelationship> FriendRelationship { get; set; }
        public virtual ICollection<FriendRequest> FriendRequest { get; set; }
    }
}