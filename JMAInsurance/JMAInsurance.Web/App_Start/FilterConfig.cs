using JMAInsurance.ApplicationShared.InfrastructureShared.ExceptionLoggingFilter;
using System.Web;
using System.Web.Mvc;

namespace JMAInsurance.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionLoggingFilter());
        }
    }
}
