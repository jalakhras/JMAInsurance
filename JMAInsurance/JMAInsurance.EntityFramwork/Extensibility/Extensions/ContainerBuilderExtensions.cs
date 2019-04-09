using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using JMAInsurance.EntityFramwork.Extensibility.Abstractions;
using JMAInsurance.EntityFramwork.Extensibility.Attributes;

namespace JMAInsurance.EntityFramwork.Extensibility.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterDependency(this ContainerBuilder builder, Type dependency)
        {
            var featureAttribute = dependency.GetCustomAttribute<FeatureAttribute>();
            var featureName = featureAttribute != null ? featureAttribute.Name : "";

            var registration = builder.RegisterType(dependency).AsSelf()
                .WithProperty("Feature", featureName)
                .WithMetadata("Feature", featureName)
                .InstancePerLifetimeScope();

            var excludedTypes = new Type[] { typeof(IDependency), typeof(ISingletonDependency), typeof(IUnitOfWorkDependency), typeof(ITransientDependency) };

            var interfaceTypes = dependency.GetInterfaces()
                .Concat(dependency.GetAbstractClasses())
                .Where(x => x.IsAssignableTo<IDependency>()).Except(excludedTypes).ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                registration = registration.As(interfaceType);
                if (interfaceType.IsAssignableTo<ISingletonDependency>())
                {
                    registration = registration.SingleInstance();
                }
                else if (interfaceType.IsAssignableTo<IUnitOfWorkDependency>())
                {
                    registration = registration.InstancePerLifetimeScope();
                }
                else if (interfaceType.IsAssignableTo<ITransientDependency>())
                {
                    registration = registration.InstancePerDependency();
                }
            }

            return registration;
        }
    }
}
