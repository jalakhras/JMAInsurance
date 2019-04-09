using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMAInsurance.EntityFramwork.Implementation
{
    public static class Extensions
    {
        public static IQueryable<T> Include<T>(this IQueryable<T> source, Expression<Func<T, object>>[] expressions)
        {
            foreach (Expression<Func<T, object>> expression in expressions)
                source = source.Include<T, object>(expression);
            return source;
        }
    }
}
