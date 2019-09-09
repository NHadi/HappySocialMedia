using System;
using System.Collections.Generic;

namespace Happy5SocialMedia.Message.Domain.Model
{
    public partial class Messages
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public Guid ParticipantId { get; set; }
        public string ContentMessage { get; set; }
        public Guid? Status { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual ActivityStatus StatusNavigation { get; set; }
    }
}