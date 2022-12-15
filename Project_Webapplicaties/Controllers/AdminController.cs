using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Definux.Utilities.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.Models;
using Project_Webapplicaties.ViewModels;

namespace Project_Webapplicaties.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly ITeamRepository _teamRepository;

        public AdminController(IUnitOfWork uow,ITeamRepository teamRepository)
        {
            _uow = uow;
            _teamRepository = teamRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Create,Delete,Update Player

        public IActionResult AddPlayer()
        {
            ViewBag.Teams = GetTeams();
            return View();
        }
        public async Task<ActionResult<IEnumerable<Player>>> EditOrDeletePlayer()
        {
            var player = await _uow.PlayerRepository.GetAll().Include(x=>x.Team).ToListAsync();
            return View(player);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayer(Player player)
        {
            _uow.PlayerRepository.Create(player);
            await _uow.Save();
            TempData["SuccessMessage"] = "Speler is toegevoegd";
            return RedirectToAction("AddPlayer");
        }

        [HttpGet]
        public async Task<ActionResult<Player>> EditPlayer(int id,AddPlayerViewModel model)
        {
            ViewBag.Teams = GetTeams();
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
            return RedirectToAction("EditOrDeletePlayer");
        }

        [HttpGet]
        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            Player player = await _uow.PlayerRepository.GetById(id);
            if (player == null) return NotFound();
            _uow.PlayerRepository.Delete(player);
            await _uow.Save();
            return RedirectToAction("EditOrDeletePlayer");
        }

        #endregion

        #region Create,Delete,Update Team

        public IActionResult AddTeam()
        {
            return View();
        }
        public async Task<ActionResult<IEnumerable<Team>>> EditOrDeleteTeam()
        {
            var team = await _uow.TeamRepository.GetAll().ToListAsync();
            return View(team);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> AddTeam(Team team)
        {
            _uow.TeamRepository.Create(team);
            await _uow.Save();
            return RedirectToAction("AddTeam");
        }

        [HttpGet]
        public async Task<ActionResult<Team>> EditTeam(int id)
        {
            var team = await _uow.TeamRepository.GetById(id);
            if (team == null) return NotFound();
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeam(int id, Team team)
        {
            if (id != team.TeamId) return BadRequest();
            _uow.TeamRepository.Update(team);
            await _uow.Save();
            return RedirectToAction("EditOrDeleteTeam");
        }

        [HttpGet]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            Team team = await _uow.TeamRepository.GetById(id);
            if (team == null) return NotFound();
            _uow.TeamRepository.Delete(team);
            await _uow.Save();
            return RedirectToAction("EditOrDeleteTeam");
        }

        #endregion


        private List<SelectListItem> GetTeams()
        {
            var teams = new List<SelectListItem>();
            PaginatedList<Team> team = _teamRepository.GetTeams("Name", SortOrder.Ascending);
            teams = team.Items.Select(x => new SelectListItem()
            {
                Value = x.TeamId.ToString(),
                Text = x.Name
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "-- Selecteer een team --"
            };
            teams.Insert(0,defItem);
            return teams;
        }
    }
}
