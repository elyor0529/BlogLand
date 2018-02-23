using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogLand
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Search",
               url: "Search/{search}",
               defaults: new { controller = "Home", action = "Search" }
           );

            routes.MapRoute(
               name: "Tag",
               url: "Tag/{tag}",
               defaults: new { controller = "Home", action = "Tag" }
           );

            routes.MapRoute(
               name: "Category",
               url: "Category/{category}",
               defaults: new { controller = "Home", action = "Category" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Posts", id = UrlParameter.Optional }
            );
        }
    }
}
