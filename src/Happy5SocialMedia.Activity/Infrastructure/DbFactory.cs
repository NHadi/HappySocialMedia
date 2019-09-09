using Happy5SocialMedia.Activity.Domain.Model;
using Happy5SocialMedia.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Activity.Infrastructure
{
    public class DataContextFactory : IDesignTimeDbContextFactory<Happy5socialmedia_ActivityContext>
    {
        public Happy5socialmedia_ActivityContext CreateDbContext(string[] args)
        {
            // Used only for EF .NET Core CLI tools (update database/migrations etc.)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<Happy5socialmedia_ActivityContext>()
                .UseSqlServer(config.GetConnectionString(Global.DbConnection.ActivityConnection));

            return new Happy5socialmedia_ActivityContext(optionsBuilder.Options);
        }
    }
}
