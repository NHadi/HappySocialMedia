using System;
using System.Collections.Generic;

namespace Happy5SocialMedia.Message.Domain.Model
{
    public partial class Conversation
    {
        public Conversation()
        {
            Messages = new HashSet<Messages>();
            Participant = new HashSet<Participant>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserCreator { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<Participant> Participant { get; set; }
    }
}