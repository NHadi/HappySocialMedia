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
                    url = _configuration.GetSection("UserService").Value;
                    break;
                case ServiceType.Acitivity:
                    url = _configuration.GetSection("AcitivityService").Value;
                    break;
                case ServiceType.Message:
                    url = _configuration.GetSection("MessageService").Value;
                    break;
                case ServiceType.Post:
                    url = _configuration.GetSection("PostService").Value;
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
