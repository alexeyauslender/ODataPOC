
using System.Web.Mvc;

namespace ODataPOC.Controllers
{
   [Authorize] 
   //[RoutePrefix("adfs/oauth2/authorize")]
    public class HomeController : Controller
    {
       //[Route]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
    