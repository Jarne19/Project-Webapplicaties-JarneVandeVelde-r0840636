using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _uow;

        public AdminController(IUnitOfWork uow) { _uow = uow; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPlayer()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayer(Player player)
        {
            _uow.PlayerRepository.Create(player);
            await _uow.Save();
            return RedirectToAction("AddPlayer");
        }

        [HttpGet]
        public async Task<ActionResult<Player>> EditPlayer(int id)
        {
            var player = await _uow.PlayerRepository.GetById(id);
            if (player == null) return NotFound();
            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer(int id, Player player)
        {
            if (id != player.PlayerId) return BadRequest();
            _uow.PlayerRepository.Update(player);
            await _uow.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            Player player = await _uow.PlayerRepository.GetById(id);
            if(player == null) return NotFound();
            _uow.PlayerRepository.Delete(player);
            await _uow.Save();
            return RedirectToAction("Index");
        }

    }
}
