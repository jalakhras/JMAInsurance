using JMAInsurance.ApplicationShared;
using JMAInsurance.ApplicationShared.InfrastructureShared.ValueProvider;
using JMAInsurance.ApplicationShared.InfrastructureShared.XMLModelBinder;
using JMAInsurance.Web.Infrastructure;
using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JMAInsurance.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ActiveTheme"]))
            {
                var activeTheme = ConfigurationManager.AppSettings["ActiveTheme"];
                ViewEngines.Engines.Insert(0, new ThemeViewEngine(activeTheme));
            };
            ModelBinderProviders.BinderProviders.Insert(0, new XMLModelBinderProvider());
            ValueProviderFactories.Factories.Insert(0, new HttpValueProviderFactory());

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error()
        {
            Debug.WriteLine("test");
        }

    }
}
