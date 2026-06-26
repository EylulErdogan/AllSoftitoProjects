using Microsoft.AspNetCore.Mvc;

namespace carWorldDbFirstProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
