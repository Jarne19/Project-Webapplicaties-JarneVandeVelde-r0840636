using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.Models;
using Project_Webapplicaties.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace Project_Webapplicaties.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;

        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            TeamListViewModel team = new TeamListViewModel();
            team.Teams = _uow.TeamRepository.GetAll().ToList();
            GameListViewModel game = new GameListViewModel();
            game.Games = _uow.GameRepository.GetAll().ToList();
            SponsorListViewModel sponsor = new SponsorListViewModel();
            sponsor.Sponsors = _uow.SponsorRepository.GetAll().ToList();
            HomeListViewModel vm = new HomeListViewModel(team,game,sponsor);
            //GameListViewModel vm = new GameListViewModel();
            //vm.Games = _uow.GameRepository.GetAll().Include(x=>x.Team).Include(x=>x.Referee).ToList();
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
