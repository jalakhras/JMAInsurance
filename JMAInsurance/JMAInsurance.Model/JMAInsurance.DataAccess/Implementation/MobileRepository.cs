using EPM.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using EPM.Models;

namespace EPM.DataAccess.Implementation
{
    class MobileRepository<T> : IMobileRepository<T> where T : class
    {
        private VROContext _dbContext;
        public MobileRepository(VROContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Configuration.LazyLoadingEnabled = true;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
