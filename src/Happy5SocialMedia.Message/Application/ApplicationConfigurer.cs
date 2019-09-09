using Happy5SocialMedia.Message.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Happy5SocialMedia.Message.Application
{
    public class ApplicationConfigurer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IMessageService, MessageService>();
        }
    }
}
