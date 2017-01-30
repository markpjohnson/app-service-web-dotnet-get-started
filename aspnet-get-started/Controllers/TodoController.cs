using System.Web.Mvc;

namespace aspnet_get_started.Controllers
{
	public class TodoController : Controller
	{
		// GET: Todo
		[OutputCache(Duration = 30)]
		public ActionResult Index()
		{
			return View();
		}
	}
}