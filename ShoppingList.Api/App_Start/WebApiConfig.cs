using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ShoppingList.Api.Filters;
using ShoppingList.Common.WebApi.Filters;

namespace ShoppingList.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ExceptionHandlerFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
