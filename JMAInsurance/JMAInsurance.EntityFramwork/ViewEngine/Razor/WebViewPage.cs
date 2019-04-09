using JMAInsurance.Entity;
using JMAInsurance.EntityFramwork.Extensibility.Extensions;
using PMS.Framework.ViewEngine;
using System.Web.Mvc;
using JMAInsurance.EntityFramwork.Localization;

namespace JMAInsurance.EntityFramwork.ViewEngine.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>, IViewPage
    {
        private SessionManager _sessionManager;
        private ILocalizationManager LocalizationManager => Context.Resolve<ILocalizationManager>();

        public string T(string text)
        {
            return LocalizationManager.GetString(text);
        }

        public static string GetRouteName<T>() where T : Controller
        {
            return typeof(T).Name.Replace("Controller", "");
        }

    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}
