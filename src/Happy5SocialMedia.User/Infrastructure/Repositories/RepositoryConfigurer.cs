using Happy5SocialMedia.User.Domain.Model.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.User.Infrastructure.Repositories
{
    public class RepositoryConfigurer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IAccountUserRepository, AccountUserRepository>();
        }
    }
}
