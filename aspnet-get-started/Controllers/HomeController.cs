using System.Diagnostics;
using System.Web.Mvc;

namespace aspnet_get_started.Controllers
{
	public class HomeController : Controller
	{
		[OutputCache(Duration = 30)]
		public ActionResult Index()
		{
			Trace.TraceInformation("Loading home page");
			return View();
		}

		public ActionResult About()
		{
			Trace.TraceInformation("Loading about page");
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			Trace.TraceInformation("Loading contact page");
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}