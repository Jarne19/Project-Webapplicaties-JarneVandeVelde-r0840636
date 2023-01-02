using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.Models;
using Project_Webapplicaties.ViewModels;

namespace Project_Webapplicaties.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IUnitOfWork _uow;

        public PlayerController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            PlayerListViewModel viewModel = new PlayerListViewModel();
            viewModel.Players = _uow.PlayerRepository.GetAll().Include(x=>x.Team).ToList();
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            Player player = _uow.PlayerRepository.GetAll().Where(x=>x.PlayerId == id).Include(x=>x.Team).FirstOrDefault();
            if (player != null)
            {
                PlayerDetailsViewModel vm = new PlayerDetailsViewModel()
                {
                    Name = player.Name,
                    Firstname = player.Firstname,
                    Birthdate = player.Birthdate,
                    BestLeg = player.BestLeg,
                    Position = player.Position,
                    team = player.Team
                };
                return View(vm);
            }
            else
            {
                PlayerListViewModel viewModel = new PlayerListViewModel();
                viewModel.Players = _uow.PlayerRepository.GetAll().ToList();
                return View(string.Empty,viewModel);
            }
        }

        public IActionResult Search(PlayerListViewModel vm)
        {
            if (!string.IsNullOrEmpty(vm.PlayerSearch))
            {
                vm.Players = _uow.PlayerRepository.GetAll().Where(p => p.Firstname.Contains(vm.PlayerSearch)).ToList();
            }
            else
            {
                vm.Players = _uow.PlayerRepository.GetAll().ToList();
            }

            return View("Index", vm);
        }
    }
}
