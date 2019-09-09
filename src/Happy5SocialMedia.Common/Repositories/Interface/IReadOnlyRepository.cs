using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Happy5SocialMedia.Common.Repositories.Interface
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool withTracking = true);
        IEnumerable<TEntity> GetInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);         
        IEnumerable<TEntity> GetInclude(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null, bool withTracking = true);
        TEntity GetById(object id);        
    }
}
