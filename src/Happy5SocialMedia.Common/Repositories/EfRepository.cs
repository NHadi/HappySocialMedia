using Happy5SocialMedia.Common.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Happy5SocialMedia.Common.Repositories
{
    public class EfRepository<TEntity> : IEfRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context = null;
        private readonly DbSet<TEntity> _dbSet = null;

        public EfRepository(DbContext context)
        {
            this._context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
            => _dbSet.AsEnumerable();
        
        public TEntity GetById(object id)
            => _dbSet.Find(id);
        public void Insert(TEntity entitiy)
         => _dbSet.Add(entitiy);
        public void InsertRange(List<TEntity> entitiy)
            => _dbSet.AddRange(entitiy);
        public void Update(TEntity entitiy)
        {
            _dbSet.Attach(entitiy);
            _context.Entry(entitiy).State = EntityState.Modified; 
        }
        public void UpdateRange(List<TEntity> entitiy)
        {
            foreach (var item in entitiy)
            {
                _dbSet.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
            }
        }
        public void Delete(TEntity entitiy)
            => _dbSet.Remove(entitiy);
        public void DeleteRange(List<TEntity> entities)
            => _dbSet.RemoveRange(entities);
        public void Save()
        => _context.SaveChanges();

        public void BeginTransaction()
        => _context.Database.BeginTransaction();
        public void CommitTransaction()
        => _context.Database.CommitTransaction();
        public void RollbackTransaction()
        => _context.Database.RollbackTransaction();
        public void DisposeTransaction()
            => _context.Database.CurrentTransaction.Dispose();       

        public IEnumerable<TEntity> GetInclude(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null, bool withTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes(query);
            }

            query = query.Where(predicate);

            if (withTracking == false)
            {
                query = query.Where(predicate).AsNoTracking();
            }

            return query.AsEnumerable();

        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool withTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            query = query.Where(predicate);
            if (withTracking == false)
            {
                query = query.Where(predicate).AsNoTracking();
            }

            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> GetInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes(query);
            }

            return query.AsEnumerable();
        }
    }
}
