using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Akkoc.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product",
                url: "Urunlerimiz/{name}",
                defaults: new { controller = "Product", action = "Detail" },
                namespaces: new string[] { "Akkoc.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Slider",
                url: "Haberler/{title}",
                defaults: new { controller = "Slider", action = "Detail"},
                namespaces: new string[] { "Akkoc.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Akkoc.Web.Controllers" }
            );
        }
    }
}
