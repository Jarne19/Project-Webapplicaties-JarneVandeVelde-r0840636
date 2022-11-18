using Microsoft.AspNetCore.Mvc;
using Project_Webapplicaties.Data.Repository.Interfaces;

namespace Project_Webapplicaties.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public AdminController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPlayer()
        {
            throw new System.NotImplementedException();
        }
    }
}
