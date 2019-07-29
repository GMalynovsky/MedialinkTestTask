using Medialink.Api.Controllers;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.AspNet.WebApi;
namespace Medialink.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            container.RegisterType<ICalculatorService, CalculatorService>();
            //container.RegisterType<MathController>(new InjectionProperty("Service", container.Resolve<ICalculatorService>()));
            container.RegisterType<MathController>(new InjectionField("Service", container.Resolve<ICalculatorService>()));

            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
