using Owin;
using System.Web.Http;

namespace JMAInsurance.EntityFramwork.Extensibility.Abstractions
{
    public interface IStartup : ISingletonDependency
    {
        void ConfigureApp(IAppBuilder app, HttpConfiguration config);
    }
}
