using ItStepSDP211.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ItStepSDP211
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", // Home / Index / 1
                defaults: new { controller = "Home",action = "Index", id = UrlParameter.Optional }
               /* constraints: new { controller = "^P.*", id=@"\d{2}", httpMethod = new HttpMethodConstraint("GET")} *///Players/Index
            );
         /*   Route newRoute = new Route("{controller}/{action}", new MvcRouteHandler()); //Home/Index   /Home/2
            Route newRoute2 = new Route("{controller}/{id}", new MvcRouteHandler()); //Home/Index   /Home/2
            routes.Add(newRoute);
            routes.Add(newRoute2);*/
        } 
    }
}
