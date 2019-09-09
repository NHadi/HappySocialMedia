using System;
using System.Collections.Generic;

namespace Happy5SocialMedia.Message.Domain.Model
{
    public partial class Participant
    {
        public Participant()
        {
            Messages = new HashSet<Messages>();
        }

        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public Guid UserAccount { get; set; }
        public Guid Status { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual ActivityStatus StatusNavigation { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}