using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common.DTO
{
    public class ApiBadRequestResponse : ApiResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> InnerException { get; }
        public ApiBadRequestResponse(int code, string message)
            : base(400)
        {
            Code = code;
            Message = message;            
        }
    }
}
