using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ZIMOAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{par}",
                 defaults: new { controller = "ZIMO", action = "Getproduits", par = RouteParameter.Optional }/*,
                defaults: new { id = RouteParameter.Optional }*/
            );
        }
    }
}
