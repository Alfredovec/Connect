using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Connect.Api.App_Start;
using Connect.Infrastructure.DI;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;

namespace Connect.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<DomainModule>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var cfg = AutomapperConfig.Configure();
            builder.RegisterInstance(cfg.CreateMapper()).As<IMapper>();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}s/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Swagger UI",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString().TrimEnd('/'), "swagger/ui/index")
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
