using Happy5SocialMedia.Common.API.Enum;
using Happy5SocialMedia.Common.API.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common.API
{
    public class UrlApiFactory : IUrlApiFactory
    {
        private readonly IConfiguration _configuration;
        public UrlApiFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetUrl(ServiceType serviceType)
        {
            string url = null;

            switch (serviceType)
            {
                case ServiceType.User:
                    url = _configuration.GetSection("UserUrl").Value;
                    break;
                case ServiceType.Activity:
                    url = _configuration.GetSection("ActivityUrl").Value;
                    break;
                case ServiceType.Message:
                    url = _configuration.GetSection("MessageUrl").Value;
                    break;
                case ServiceType.Post:
                    url = _configuration.GetSection("PostUrl").Value;
                    break;
                default:
                    break;
            }

            return url;
        }

        public string GetUrl(string serviceType)
        => _configuration.GetSection(serviceType).Value;
    }
}
