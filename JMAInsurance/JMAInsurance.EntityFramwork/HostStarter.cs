using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using System.Web.Http;
using JMAInsurance.EntityFramwork.Extensibility.Extensions;
using JMAInsurance.EntityFramwork.Extensibility;
using JMAInsurance.EntityFramwork.ViewEngine.Razor;
using System.Web.Mvc;
using System.Web.Routing;
using JMAInsurance.EntityFramwork.Filters;
using JMAInsurance.EntityFramwork.MVC;
using JMAInsurance.EntityFramwork.Host;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;

namespace JMAInsurance.EntityFramwork
{
    public static class HostStarter
    {
        public static void CreateHostContainer(params Assembly[] extensions)
        {
            CreateHostContainer((builder, config) => { }, extensions);
        }

        public static void CreateHostContainer(Action<ContainerBuilder, HttpConfiguration> registrations, params Assembly[] extensions)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();

            builder.RegisterType<ExtensionManager>().As<IExtensionManager>().SingleInstance()
                .WithParameter(new NamedParameter("extensions", extensions));
            builder.RegisterType<ExtensionLoader>().As<IExtensionLoader>().SingleInstance();
            builder.RegisterType<ModuleAwareViewEngine>().InstancePerDependency();
            builder.Register(ctx => RouteTable.Routes).SingleInstance();
            builder.Register(ctx => GlobalConfiguration.Configuration.Routes).SingleInstance();
            builder.Register(ctx => config).SingleInstance();

            var container = builder.Build();

            var scope = container.BeginLifetimeScope(b =>
            {
                container.Resolve<IExtensionLoader>().RegisterExtensions(b);
            });

            System.Web.Mvc.ViewEngines.Engines.Clear();
            System.Web.Mvc.ViewEngines.Engines.Add(scope.Resolve<ModuleAwareViewEngine>());

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
            FilterProviders.Providers.Add(new FiltersProvider());

            var hostEvents = scope.Resolve<IEnumerable<IHostEvents>>();
            foreach (var hostEvent in hostEvents)
            {
                hostEvent.Activated();
            }

            IoC.Container = scope;

            DependencyResolver.SetResolver(new AutofacDependencyResolver(scope));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(scope);

            registrations(builder, config);
        }

    }
}
