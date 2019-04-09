using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EPM.DataAccess
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
