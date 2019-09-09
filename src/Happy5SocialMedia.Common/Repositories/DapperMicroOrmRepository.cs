using Dapper;
using Happy5SocialMedia.Common.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Happy5SocialMedia.Common.Repositories
{
    public class DapperMicroOrmRepository<TEntity> : IDapperMicroOrmRepository<TEntity> where TEntity : class

    {
        private readonly IDbConnection _sqlConnection;
        public DapperMicroOrmRepository(IDbConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }


        public IEnumerable<TEntity> FromSql(string query = null, object param = null)
        {

            using (_sqlConnection)
            {
                _sqlConnection.Open();
                return _sqlConnection.Query<TEntity>(query, param);
            }
        }

        public void FromSqlWithoutReturn(string query = null, object param = null)
        {

            using (_sqlConnection)
            {
                _sqlConnection.Open();
                _sqlConnection.Execute(query, param);
            }
        }
    }
}
