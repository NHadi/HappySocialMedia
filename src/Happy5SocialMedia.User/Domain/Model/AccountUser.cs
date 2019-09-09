using System;
using System.Collections.Generic;

namespace Happy5SocialMedia.User.Domain.Model
{
    public partial class AccountUser
    {
        public Guid Id { get; set; }
        public Guid? Parent { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}