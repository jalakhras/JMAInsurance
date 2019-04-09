using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Owin;
using Microsoft.Owin.Cors;
using JMAInsurance.EntityFramwork.Extensibility.Abstractions;

[assembly: OwinStartup(typeof(JMAInsurance.EntityFramwork.Startup))]
namespace JMAInsurance.EntityFramwork
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = DependencyResolver.Current.GetService<HttpConfiguration>();
            var scope = DependencyResolver.Current.GetService<ILifetimeScope>();

            app.UseAutofacMiddleware(scope);
            app.UseAutofacMvc();

            app.Map("/api", apiApp =>
            {
                apiApp.UseCors(CorsOptions.AllowAll);
                apiApp.UseWebApi(GlobalConfiguration.Configuration);
                apiApp.UseAutofacWebApi(GlobalConfiguration.Configuration);
            });

            var startups = DependencyResolver.Current.GetServices<IStartup>();

            foreach (var startup in startups)
            {
                startup.ConfigureApp(app, config);
            }

            config.EnsureInitialized();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
