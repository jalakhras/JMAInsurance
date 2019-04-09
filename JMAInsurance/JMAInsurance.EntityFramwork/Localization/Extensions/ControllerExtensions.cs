using System.Web.Mvc;
using Autofac;
using JMAInsurance.EntityFramwork.Extensibility.Extensions;
using JMAInsurance.EntityFramwork.Localization;

namespace PMS.Framework.Localization.Extensions
{
    public static class ControllerExtensions
    {
        public static string T(this Controller controller, string text)
        {
            return controller.HttpContext.Resolve<ILocalizationManager>().GetString(text);
        }
    }
}