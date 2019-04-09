using EPM.DataAccess;
using JMAInsurance.Core;
using JMAInsurance.EntityFramwork;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JMAInsurance.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            MvcHandler.DisableMvcResponseHeader = true;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeContainer(this);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void InitializeContainer(MvcApplication self)
        {
            HostStarter.CreateHostContainer(GetExtensions().ToArray());
        }
        private static IEnumerable<Assembly> GetExtensions()
        {
            //PMS.Core
            yield return typeof(MigrationContext).Assembly;
            // EPM.BusinessLogic
            //yield return typeof(IApplicantService).Assembly;
            // EPM.DMS
            //yield return typeof(DmsProviderManager).Assembly;
            //// EPM.Integration
            //yield return typeof(ProjectServerIntegration).Assembly;
            // EPM.LoggingHelper
            //yield return typeof(LoggerHelper).Assembly;
            // EPM.Models
            yield return typeof(IRepository<>).Assembly;
            // EPM.Services
            //yield return typeof(IGenericService<>).Assembly;
            // VRO.Web
            yield return typeof(MvcApplication).Assembly;
            // EPM.MobileAPI
            //yield return typeof(MobileAuthorizeAttribute).Assembly;
            //// EPM.Integration
            //yield return typeof(IProjectServerIntegration).Assembly;
        }

    }
}
