using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using JMAInsurance.EntityFramwork.Extensibility.Extensions;

namespace JMAInsurance.EntityFramwork.Extensibility
{
    public class ExtensionLoader : IExtensionLoader
    {
        private readonly IExtensionManager _extensionManager;

        public ExtensionLoader(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        public void RegisterExtensions(ContainerBuilder builder)
        {
            var assemblies = _extensionManager.GetExtensions().ToArray();

            builder.RegisterAssemblyModules(assemblies);

            builder.RegisterControllers(assemblies);

            builder.RegisterModelBinders(assemblies);
            builder.RegisterModelBinderProvider();

            builder.RegisterApiControllers(assemblies);

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterModule<AutofacWebTypesModule>();

            foreach (var dependency in _extensionManager.GetFilteredDependencies())
            {
                builder.RegisterDependency(dependency);
            }
        }
    }
}
