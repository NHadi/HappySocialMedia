using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.User.Application.DTO
{
    public class AccountUserRespond
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<AccountUserRespond> Parents { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<AccountUserRespond> Subordinates { get; set; }
    }
}
