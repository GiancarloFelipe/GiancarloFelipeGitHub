using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PetService.MVC
{
    /// <summary>
    /// Register all the routes configuration for the PetSure Web API Application System.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register WebAPI configuration.
        /// </summary>
        /// <param name="config">The System.Web.Http.HttpServer configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Set the default route for WebAPI...
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
