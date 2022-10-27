using Microsoft.AspNetCore.Mvc;

namespace Project_Webapplicaties.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
