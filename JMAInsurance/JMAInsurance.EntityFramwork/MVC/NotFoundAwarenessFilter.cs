using System.Net;
using System.Web.Mvc;
using JMAInsurance.EntityFramwork.Filters;
using JMAInsurance.EntityFramwork.MVC;
using JMAInsurance.Framework.Extensions;

namespace JMAInsurance.Framework.ViewEngine.LayoutAwareness.Filters
{
    public class NotFoundAwarenessFilter : IActionFilter, IPermanentFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.Result.Is<HttpNotFoundResult>())
                return;

            filterContext.Result = new NotFoundViewResult();

            filterContext.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

            // prevent IIS 7.0 classic mode from handling the 404/500 itself
            filterContext.RequestContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
