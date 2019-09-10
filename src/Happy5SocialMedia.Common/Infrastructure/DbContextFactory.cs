using Happy5SocialMedia.Common.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Happy5SocialMedia.Common.Infrastructure
{
    public class DbContextFactory : IDbContextFactory        
    {
        private readonly IConfiguration _configuration;        
        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string connectionString) => _configuration.GetSection(connectionString).Value;
        public IDbConnection GetDbConnection(string connectionString) => new SqlConnection(_configuration.GetSection(connectionString).Value);
    }
}
