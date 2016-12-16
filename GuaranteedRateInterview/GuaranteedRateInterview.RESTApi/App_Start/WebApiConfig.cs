using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GuaranteedRateInterview.RESTApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "RecordsApi",
                routeTemplate: "records/{sort}",
                defaults: new { sort = RouteParameter.Optional }
            );
        }
    }
}