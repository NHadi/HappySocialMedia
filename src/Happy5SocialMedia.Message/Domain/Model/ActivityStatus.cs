using System;
using System.Collections.Generic;

namespace Happy5SocialMedia.Message.Domain.Model
{
    public partial class ActivityStatus
    {
        public ActivityStatus()
        {
            Messages = new HashSet<Messages>();
            Participant = new HashSet<Participant>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<Participant> Participant { get; set; }
    }
}