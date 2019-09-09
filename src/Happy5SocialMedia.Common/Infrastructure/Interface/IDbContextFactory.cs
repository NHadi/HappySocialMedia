using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Happy5SocialMedia.Common.Infrastructure.Interface
{
    public interface IDbContextFactory
    {
        IDbConnection GetDbConnection(string connectionString);
        string GetConnectionString(string connectionDb);
    }
}
