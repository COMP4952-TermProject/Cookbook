using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Routing;

namespace TechnicalProgrammingProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Cookbook",
                url: "Cookbooks/{id}",
                defaults: new { controller = "Cookbooks", action = "Index" }
            );

            routes.MapRoute(
                name: "ProfileEdit",
                url: "Profile/Edit",
                defaults: new { controller = "Profile", action = "Edit" }
            );

            routes.MapRoute(
                name: "Profile",
                url: "Profile/{id}",
                defaults: new { controller = "Profile", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
