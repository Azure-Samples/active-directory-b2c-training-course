using System.Web.Mvc;

namespace AwesomeComputers.Controllers
{
	[Authorize]
    public class HomeController : Controller
	{
		public ActionResult Index()
		{
            return View();
        }
    }
}