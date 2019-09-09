using Happy5SocialMedia.Common.API;
using Happy5SocialMedia.Common.API.Interface;
using Happy5SocialMedia.Common.API.Services;
using Happy5SocialMedia.Common.Infrastructure;
using Happy5SocialMedia.Common.Infrastructure.Interface;
using Happy5SocialMedia.Common.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Happy5SocialMedia.Common
{
    public static class MainBootsraper
    {
        public static void InitBootsraper(this IServiceCollection services)
        {
            services.AddTransient<IDbContextFactory, DbContextFactory>();
            services.AddTransient<IUrlApiFactory, UrlApiFactory>();
            services.AddTransient<IUserApiService, UserApiService>();
            
            RepositoryBootsraper.RegisterServices(services);
        }


        public static void ConfigSwagger(this IServiceCollection services, string description, string xmlPath)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(Global.API.Version, new Info
                {
                    Version = Global.API.Version,
                    Title = "Happy5 Social Media",
                    Description = $"Happy5 Social Media :: {description}",
                    Contact = new Contact { Name = "Nurul Hadi", Email = "nurul.hadi@outlook.com", Url = "https://github.com/NHadi" }
                });
                
                x.IncludeXmlComments(xmlPath);
            });
        }
    }
}
