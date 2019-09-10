using AutoMapper;
using Happy5SocialMedia.Common;
using Happy5SocialMedia.Common.API.Attributes;
using Happy5SocialMedia.User.Domain.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace Happy5SocialMedia.User
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InitBootsraper();

            services.AddDbContext<Happy5socialmedia_UserContext>(options =>
                options.UseSqlServer(Configuration.GetSection("ConnectionString").Value));

            //services.AddCors();

            services.AddMvcCore()
                .AddJsonFormatters(j =>j.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).AddApiExplorer();

            string basePath = PlatformServices.Default.Application.ApplicationBasePath;
            string xmlPath = Path.Combine(basePath, "WebAPI.xml");

            services.ConfigSwagger("User Service", xmlPath);

            services.AddMvc(
                options => {
                    options.Filters.Add(typeof(ValidateModelStateAttribute));
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(typeof(MappingProfile));

            //IoC for Application
            services.InitAppBootsraper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // FOR UI Interface API
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", $"Happy5 Social Media Microservices API {Global.API.Version}");
            });
        }
    }
}
