using System;
using Autofac;

namespace JMAInsurance.EntityFramwork
{
    public static class IoC
    {
        private static ILifetimeScope container;

        public static ILifetimeScope Container
        {
            get { return container; }
            set { container = value; }
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public static object Resolve(Type service)
        {
            return container.Resolve(service);
        }

        public static bool IsInitialized
        {
            get { return container != null; }
        }

        public static void Reset()
        {
            if (container == null)
                return;

            container = null;
        }
    }
}
