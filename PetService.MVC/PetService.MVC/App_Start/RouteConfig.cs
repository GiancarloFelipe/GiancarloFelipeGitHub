using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetService.MVC
{
    /// <summary>
    /// Register all the routes configuration for the PetSure Web Application System.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Register the Application Routes.
        /// </summary>
        /// <param name="routes">The routes collections.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Set the default route...
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}