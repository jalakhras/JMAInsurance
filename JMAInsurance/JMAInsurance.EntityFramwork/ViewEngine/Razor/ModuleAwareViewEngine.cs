using JMAInsurance.EntityFramwork.Extensibility;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.EntityFramwork.ViewEngine.Razor
{
    public class ModuleAwareViewEngine : RazorViewEngine
    {
        public ModuleAwareViewEngine(IExtensionManager extensionManager)
        {
            var locations = extensionManager.GetExtensions().SelectMany(x => new[] {
                $"~/Modules/{x.GetName().Name}/Views/{{1}}/{{0}}.cshtml",
                $"~/Modules/{x.GetName().Name}/Views/{{1}}/{{0}}.vbhtml",
                $"~/Modules/{x.GetName().Name}/Views/Shared/{{0}}.cshtml",
                $"~/Modules/{x.GetName().Name}/Views/Shared/{{0}}.vbhtml"
            }).ToArray();

            ViewLocationFormats = ViewLocationFormats.Concat(locations).ToArray();
            PartialViewLocationFormats = PartialViewLocationFormats.Concat(locations).ToArray();
        }
    }
}
