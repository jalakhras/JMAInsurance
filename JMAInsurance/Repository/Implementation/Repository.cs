using JMAInsurance.EntityFramwork.DbContext;
using JMAInsurance.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly JMAInsuranceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(JMAInsuranceDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }


        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            _context.Configuration.LazyLoadingEnabled = false;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue && orderBy != null)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue && orderBy != null)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             int? skip = null,
             int? take = null,
             params Expression<Func<TEntity, object>>[] include)
             where TEntity : class
        {

            _context.Configuration.LazyLoadingEnabled = false;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = query.Include(include.ToString());
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue && orderBy != null)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue && orderBy != null)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        protected virtual IQueryable<TEntity> GetQueryableLazy<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true)
            where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            _context.Configuration.LazyLoadingEnabled = true;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue && orderBy != null)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue && orderBy != null)
            {
                query = query.Take(take.Value);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        /// <summary>
        /// return all rows for specified entity
        /// </summary>
        /// <param name="orderBy">order by</param>
        /// <param name="skip">int for paging</param>
        /// <param name="take">int for paging</param>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> GetQueryableWithLazy<TEntity>(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           int? skip = null,
           int? take = null,
           bool asNoTracking = false)
           where TEntity : class
        {
            _context.Configuration.LazyLoadingEnabled = true;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }



            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue && orderBy != null)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue && orderBy != null)
            {
                query = query.Take(take.Value);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }


        /// <summary>
        /// return all rows for specified entity
        /// </summary>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigation properties</param>
        /// <param name="skip">int for paging</param>
        /// <param name="take">int for paging</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return GetQueryable<T>(null, orderBy, includeProperties, skip, take).ToList();
        }

        /// <summary>
        /// return all rows for specified entity with lazy loading
        /// </summary>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigation properties</param>
        /// <param name="skip">int for paging</param>
        /// <param name="take">int for paging</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllLazy(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true)
        {
            return GetQueryableLazy<T>(null, orderBy, includeProperties, skip, take, asNoTracking).ToList();
        }

        public virtual IEnumerable<T> GetAllLazy(
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Expression<Func<T, bool>> filter = null,
           int? skip = null,
           int? take = null,
           bool asNoTracking = true)
        {
            return GetQueryableWithLazy<T>(filter, orderBy, skip, take, asNoTracking).ToList();
        }

        /// <summary>
        /// return all rows for specified entity 
        /// </summary>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigation properties</param>
        /// <param name="skip">int for paging</param>
        /// <param name="take">int for paging</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return await GetQueryable<T>(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        /// <summary>
        /// get list of rows based on filter
        /// </summary>
        /// <param name="filter">where conditions(expression)</param>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigation properties</param>
        /// <param name="skip">int for paging -- nullable</param>
        /// <param name="take">int for paging -- nullable</param>
        /// <returns></returns>
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return GetQueryable<T>(filter, orderBy, includeProperties, skip, take).ToList();
        }

        /// <summary>
        /// get list of rows based on filter
        /// </summary>
        /// <param name="filter">where conditions(expression)</param>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigation properties</param>
        /// <param name="skip">int for paging -- nullable</param>
        /// <param name="take">int for paging -- nullable</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetLazy(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true)
        {
            return GetQueryableWithLazy<T>(filter, orderBy, skip, take, asNoTracking).ToList();
        }

        /// <summary>
        /// get list of rows based on filter
        /// </summary>
        /// <param name="filter">where conditions(expression)</param>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigation properties</param>
        /// <param name="skip">int for paging -- nullable</param>
        /// <param name="take">int for paging -- nullable</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return await GetQueryable<T>(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        /// <summary>
        /// get single or default record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="includeProperties">navigations</param>
        /// <returns></returns>
        public virtual T GetOne(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = "")
        {
            return GetQueryable<T>(filter, null, includeProperties).SingleOrDefault();
        }

        /// <summary>
        /// get single or default record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="includeProperties">navigations</param>
        /// <returns></returns>
        public virtual async Task<T> GetOneAsync(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null)
        {
            return await GetQueryable<T>(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        /// <summary>
        /// get first record or default
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigations</param>
        /// <returns></returns>
        public virtual T GetFirst(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            return GetQueryable<T>(filter, orderBy, includeProperties).FirstOrDefault();
        }

        /// <summary>
        /// get first record or default using lazy Loading
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigations</param>
        /// <returns></returns>
        public virtual T GetFirstLazy(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            return GetQueryableLazy<T>(filter, orderBy, includeProperties).FirstOrDefault();
        }

        /// <summary>
        /// get first record or default
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">navigations</param>
        /// <returns></returns>
        public virtual async Task<T> GetFirstAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null)
        {
            return await GetQueryable<T>(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        /// <summary>
        /// get row by id
        /// </summary>
        /// <param name="id">id of needed row</param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// get row by id
        /// </summary>
        /// <param name="id">id of needed row</param>
        /// <returns></returns>
        public virtual Task<T> GetByIdAsync(object id)
        {
            return _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// count records for selected entity
        /// </summary>
        /// <typeparam name="TEntity">entity to be count its records</typeparam>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).Count();
        }

        /// <summary>
        /// count records for selected entity
        /// </summary>
        /// <typeparam name="TEntity">entity to be count its records</typeparam>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).CountAsync();
        }

        /// <summary>
        /// check if record exist in entity
        /// </summary>
        /// <typeparam name="TEntity">entity to be check</typeparam>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).Any();
        }

        /// <summary>
        /// check if record exist in entity
        /// </summary>
        /// <typeparam name="TEntity">entity to be check</typeparam>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).AnyAsync();
        }

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="entity">object of entity to be added</param>
        public virtual void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// add list of records on selected entity
        /// </summary>
        /// <param name="entities">objects to be added</param>
        public void Create(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        /// <summary>
        /// update record in entity
        /// </summary>
        /// <param name="entity">object to be updated</param>
        public virtual void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }

        /// <summary>
        /// delete record from entity based on record id
        /// </summary>
        /// <param name="id">id of record</param>
        public virtual void Delete(object id)
        {
            T entityToDelete = _context.Set<T>().Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                if (entityToDelete != null) _dbSet.Attach(entityToDelete);
            }
            if (entityToDelete != null) _dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// delete multible records from entity
        /// </summary>
        /// <param name="entities">records to be deleted</param>
        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                if (_context.Entry(item).State == EntityState.Detached)
                {
                    _dbSet.Attach(item);
                }
            }
            _context.Set<T>().RemoveRange(entities);
        }

        /// <summary>
        /// delete record from entity
        /// </summary>
        /// <param name="entity">record to be deleted</param>
        public void Delete(T entity)
        {
            //_context.Set<T>().Attach(entity);
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// save changes done on context
        /// </summary>
        public virtual int Save()
        {
            int result = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    result = _context.SaveChanges();
                    scope.Complete();
                }
                return result;
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
                return result;
            }
        }

        public void ExecuteSqlCommand(string command)
        {
            _context.Database.ExecuteSqlCommand(command);
        }

        public List<TEntity> GetFromSP<TEntity>(string spName, string paramsName, params SqlParameter[] sqlParams)
        {
            return _context.Database.SqlQuery<TEntity>(spName.TrimEnd() + " " + paramsName, paramsName).ToList();
        }

        /// <summary>
        /// return exceptions that happened on context
        /// </summary>
        /// <param name="e"></param>
        protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }

        public IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<T, object>>[] include)
        {
            return GetQueryable<T>(filter, orderBy, skip, take, include).ToList();
        }


    }

}
