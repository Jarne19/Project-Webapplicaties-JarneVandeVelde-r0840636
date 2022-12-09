using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Project_Webapplicaties.Data;
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
            viewModel.Players = _uow.PlayerRepository.GetAll().ToList();
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            Player player = _uow.PlayerRepository.GetAll().Where(x=>x.PlayerId == id).FirstOrDefault();
            if (player != null)
            {
                PlayerDetailsViewModel vm = new PlayerDetailsViewModel()
                {
                    Name = player.Name,
                    Firstname = player.Firstname,
                    Birthdate = player.Birthdate,
                    BestLeg = player.BestLeg,
                    PastDetails = player.PastDetails,
                    Age = player.Age
                };
                return View(vm);
            }
            else
            {
                PlayerListViewModel viewModel = new PlayerListViewModel();
                viewModel.Players = _uow.PlayerRepository.GetAll().ToList();
                return View("",viewModel);
            }
        }
    }
}
