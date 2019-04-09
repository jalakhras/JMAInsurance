using System.Web.Mvc;

namespace JMAInsurance.EntityFramwork.MVC

{
    public class NotFoundViewResult : ViewResult
    {
        protected override ViewEngineResult FindView(ControllerContext context)
        {
            return ViewEngines.Engines.FindView(context, "NotFound", MasterName);
        }
    }
}
