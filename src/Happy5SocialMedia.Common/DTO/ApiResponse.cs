using Newtonsoft.Json;

namespace Happy5SocialMedia.Common.DTO
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }


        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "Success";
                case 400:
                    return "Something Wrong";
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }
}