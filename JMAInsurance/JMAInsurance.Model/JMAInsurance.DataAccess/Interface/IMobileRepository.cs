using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EPM.DataAccess.Interface
{
    public interface IMobileRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T,bool>> predicate);
        
        T Get(Expression<Func<T,bool>> predicate);
        T GetById(int id);
    }
}
