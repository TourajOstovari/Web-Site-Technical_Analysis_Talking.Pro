using System.Web.Mvc;
using System.Web.Routing;

namespace Technical_Analysis_Talking.Pro
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Home",
            url: "{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Admin",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Admin", action = "login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
