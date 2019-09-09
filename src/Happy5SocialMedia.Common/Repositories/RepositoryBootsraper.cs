using Happy5SocialMedia.Common.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common.Repositories
{
    public class RepositoryBootsraper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IDapperMicroOrmRepository<>), typeof(DapperMicroOrmRepository<>));
            services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
        }
    }
}
