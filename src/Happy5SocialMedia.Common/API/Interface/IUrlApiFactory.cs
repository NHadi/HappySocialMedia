using Happy5SocialMedia.Common.API.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common.API.Interface
{
    public interface IUrlApiFactory
    {
        string GetUrl(ServiceType serviceType);
        string GetUrl(string serviceType);
    }
}
