using Happy5SocialMedia.Activity.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Happy5SocialMedia.Activity.Application
{
    public class ApplicationConfigurer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IFriendService, FriendService>();
            
        }
    }
}
