using Happy5SocialMedia.Activity.Application;
using Happy5SocialMedia.Activity.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Activity
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
