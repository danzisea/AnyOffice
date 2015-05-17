using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Quaider.Component.Data
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        protected BaseRepository()
        {
            
        }

        public IQueryable<TEntity> Entities
        {
            get { throw new NotImplementedException(); }
        }

        public TEntity GetByKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Expression<Func<TEntity, object>> propertyExpression, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}