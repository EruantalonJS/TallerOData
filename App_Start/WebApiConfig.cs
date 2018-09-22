﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace MusicStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
			//var cors = new EnableCorsAttribute("http://localhost:63249", "*", "*");
			//config.EnableCors(cors);
        }
    }
}
