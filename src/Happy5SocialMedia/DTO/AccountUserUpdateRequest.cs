using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.DTO
{
    public class AccountUserUpdateRequest
    {
        public Guid? Parent { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
