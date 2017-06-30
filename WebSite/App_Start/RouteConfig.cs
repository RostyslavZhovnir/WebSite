using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Jobs",
                url: "Jobs",
                defaults: new { controller = "AdTables", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Details",
               url: "Jobs/Details/{id}",
               defaults: new { controller = "AdTables", action = "Details", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
