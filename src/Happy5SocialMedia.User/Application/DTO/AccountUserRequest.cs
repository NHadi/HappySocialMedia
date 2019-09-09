using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.User.Application.DTO
{
    public class AccountUserRequest
    {
        public Guid? Parent { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }        
        public string Email { get; set; }       
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
