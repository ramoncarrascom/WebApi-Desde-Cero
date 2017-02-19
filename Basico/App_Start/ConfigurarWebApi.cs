using System.Web.Http;
using Owin;
using System.Web.Http.Dispatcher;
using IoC;
using Castle.Windsor;

namespace Basico.App_Start
{
    public class ConfiguracionWebApi
    {
        public static void ConfigureWebApi(IAppBuilder app, HttpConfiguration config, IWindsorContainer contenedor)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );
            config.Routes.MapHttpRoute("NotFound", "api/{*path}", new { controller = "Error", action = "NotFound" });

            config.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(contenedor));
            
            app.UseWebApi(config);
        }
    }
}