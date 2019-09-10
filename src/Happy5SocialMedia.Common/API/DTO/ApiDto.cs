using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common.API.DTO
{
    public class ApiDto
    {
        public int statusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string message { get; set; }        
    }
}
