using Happy5SocialMedia.Message.Application;
using Happy5SocialMedia.Message.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Message
{
    public static class MainBootsraper
    {
        public static void InitAppBootsraper(this IServiceCollection services)
        {
            RepositoryConfigurer.RegisterServices(services);
            ApplicationConfigurer.RegisterServices(services);
        }
    }
}
