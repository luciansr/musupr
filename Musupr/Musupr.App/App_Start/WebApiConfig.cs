using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Musupr.Infrastructure;
using System.Net.Http.Headers;

namespace Musupr.App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services                        
            config.DependencyResolver = new UnityResolver(Factory.Instance);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
