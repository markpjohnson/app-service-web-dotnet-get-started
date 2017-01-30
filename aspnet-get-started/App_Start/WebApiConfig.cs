using System.Web.Http;

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
		}
	}
}