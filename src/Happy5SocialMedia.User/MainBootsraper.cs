using Happy5SocialMedia.User.Application;
using Happy5SocialMedia.User.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Happy5SocialMedia.User
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
