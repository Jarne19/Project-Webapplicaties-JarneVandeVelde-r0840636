using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.Models;
using Project_Webapplicaties.ViewModels;

namespace Project_Webapplicaties.Controllers
{
    public class GameController : Controller
    {
        private readonly IUnitOfWork _uow;

        public GameController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            GameListViewModel vm = new GameListViewModel();
            vm.Games = _uow.GameRepository.GetAll().Include(x=>x.Referee).Include(x=>x.Team).OrderBy(x=>x.PlayDate).ToList();
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            Game game = _uow.GameRepository.GetAll().Where(x => x.GameId == id).Include(x => x.Referee)
                .Include(x => x.Team).FirstOrDefault();
            if (game != null)
            {
                GameDetailViewModel vm = new GameDetailViewModel()
                {
                    GameId = game.GameId,
                    PlayDate = game.PlayDate,
                    HomeTeam = game.HomeTeam,
                    AwayTeam = game.AwayTeam,
                    Referee = game.Referee,
                    Team = game.Team,
                    RefereeId = game.RefereeId,
                };
                return View(vm);
            }
            else
            {
                GameListViewModel viewModel = new GameListViewModel();
                viewModel.Games = _uow.GameRepository.GetAll().ToList();
                return View(string.Empty, viewModel);
            }
        }
    }
}
