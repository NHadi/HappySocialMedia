using Happy5SocialMedia.User.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Happy5SocialMedia.User.Application
{
    public class ApplicationConfigurer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
