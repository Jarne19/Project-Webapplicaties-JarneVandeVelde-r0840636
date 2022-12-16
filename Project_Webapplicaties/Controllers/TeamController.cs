using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.Models;
using Project_Webapplicaties.ViewModels;

namespace Project_Webapplicaties.Controllers
{
    public class TeamController : Controller
    {
        private readonly IUnitOfWork _uow;

        public TeamController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            TeamListViewModel vm = new TeamListViewModel();
            vm.Teams = _uow.TeamRepository.GetAll().Include(x=>x.Players).ToList();
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            Team team = _uow.TeamRepository.GetAll().Where(x => x.TeamId == id).FirstOrDefault();
            if (team != null)
            {
                TeamDetailsViewModel vm = new TeamDetailsViewModel()
                {
                    Name = team.Name,
                    Division = team.Division,
                    Players = _uow.PlayerRepository.GetAll().Where(x=>x.PloegId == team.TeamId).ToList(),
                };
                return View(vm);
            }
            else
            {
                TeamListViewModel model = new TeamListViewModel();
                model.Teams = _uow.TeamRepository.GetAll().Include(x=>x.Players).ToList();
                return View("",model);
            }
        }
    }
}
