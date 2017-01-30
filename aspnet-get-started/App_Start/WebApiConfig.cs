using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace aspnet_get_started
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services 

			// Web API routes 
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(name: "DefaultApi",
										routeTemplate: "api/{controller}/{id}",
										defaults: new
												{
													id = RouteParameter.Optional
												});

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
																{
																	ContractResolver = new CamelCasePropertyNamesContractResolver(),
																	DateTimeZoneHandling = DateTimeZoneHandling.Utc
																};
		}
	}
}