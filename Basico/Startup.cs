using System;
using System.Web.Http;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Basico.Startup))]

namespace Basico
{
    public class Startup
    {

        private IWindsorContainer contenedor;

        public void Configuration(IAppBuilder appBuilder)
        {

            HttpConfiguration config = new HttpConfiguration();

            contenedor = new WindsorContainer();
            contenedor.Install(FromAssembly.This());

            SwaggerConfig.Register(config);
            App_Start.ConfiguracionWebApi.ConfigureWebApi(appBuilder, config, contenedor);
        }
    }
}