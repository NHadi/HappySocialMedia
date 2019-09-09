using Happy5SocialMedia.Common;
using Happy5SocialMedia.Message.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Happy5SocialMedia.Message.Infrastructure
{
    public class DataContextFactory : IDesignTimeDbContextFactory<Happy5socialmedia_MessageContext>
    {
        public Happy5socialmedia_MessageContext CreateDbContext(string[] args)
        {
            // Used only for EF .NET Core CLI tools (update database/migrations etc.)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<Happy5socialmedia_MessageContext>()
                .UseSqlServer(config.GetConnectionString(Global.DbConnection.MessageConnection));

            return new Happy5socialmedia_MessageContext(optionsBuilder.Options);
        }
    }
}
