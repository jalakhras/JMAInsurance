using System;
using System.Web;
using Autofac;

namespace JMAInsurance.EntityFramwork.Extensibility.Extensions
{
    public static class HttpContextExtensions
    {
        public static T Resolve<T>(this HttpContextBase context) where T : class
        {
            var scope = context.Items[typeof(ILifetimeScope)] as ILifetimeScope;
            return scope?.Resolve<T>();
        }

        public static object Resolve(this HttpContextBase context, Type serviceType)
        {
            var scope = context.Items[typeof(ILifetimeScope)] as ILifetimeScope;
            return scope?.Resolve(serviceType);
        }
    }
}