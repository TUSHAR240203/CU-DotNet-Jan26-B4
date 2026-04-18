using Microsoft.AspNetCore.Mvc;

namespace NorthwindCatalog.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Categories");
        }
    }
}