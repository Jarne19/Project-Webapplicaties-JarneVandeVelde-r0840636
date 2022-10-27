using Microsoft.AspNetCore.Mvc;

namespace Project_Webapplicaties.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
