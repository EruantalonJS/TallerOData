using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using MusicStore.Data;
using Newtonsoft.Json.Serialization;

namespace MusicStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			
            // Web API routes
            config.MapHttpAttributeRoutes();

            var routeCollection = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Genre>("ODataGenres");
            var albumBuilder = builder.EntitySet<Album>("ODataAlbums").EntityType;
            albumBuilder.Ignore(a => a.Carts);
            albumBuilder.Ignore(a => a.OrderDetails);
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());
        }
    }
}
