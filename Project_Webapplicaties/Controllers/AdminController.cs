using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IRefereeRepository _refereeRepository;
        private readonly VwGerheideContext _context;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly ITeamSponsorRepository _teamSponsorRepository;

        public AdminController(IUnitOfWork uow, ITeamRepository teamRepository, IRefereeRepository refereeRepository, VwGerheideContext context, ISponsorRepository sponsorRepository, ITeamSponsorRepository teamSponsorRepository)
        {
            _uow = uow;
            _teamRepository = teamRepository;
            _refereeRepository = refereeRepository;
            _context = context;
            _sponsorRepository = sponsorRepository;
            _teamSponsorRepository = teamSponsorRepository;
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
        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayer(Player player)
        {
            _uow.PlayerRepository.Create(player);
            await _uow.Save();
            TempData["SuccessMessage"] = $"{player.Firstname} {player.Name} is toegevoegd";
            return RedirectToAction("AddPlayer");
        }
        public async Task<ActionResult<IEnumerable<Player>>> EditOrDeletePlayer()
        {
            var player = await _uow.PlayerRepository.GetAll().Include(x => x.Team).ToListAsync();
            return View(player);
        }
        [HttpGet]
        public async Task<ActionResult<Player>> EditPlayer(int id)
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

        #region Create,Delete,Update Game

        public IActionResult AddGame()
        {
            ViewBag.Teams = GetTeams();
            ViewBag.Referees = GetReferees();
            return View();
        }
        public async Task<ActionResult<IEnumerable<Game>>> EditOrDeleteGame()
        {
            var game = await _uow.GameRepository.GetAll().Include(x => x.Team).Include(x => x.Referee).ToListAsync();
            return View(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            _uow.GameRepository.Create(game);
            await _uow.Save();
            return RedirectToAction("AddGame");
        }

        [HttpGet]
        public async Task<ActionResult<Game>> EditGame(int id)
        {
            ViewBag.Teams = GetTeams();
            ViewBag.Referees = GetReferees();
            var game = await _uow.GameRepository.GetById(id);
            if (game == null) return NotFound();
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> EditGame(int id, Game game)
        {
            if (id != game.GameId) return BadRequest();
            _uow.GameRepository.Update(game);
            await _uow.Save();
            return RedirectToAction("EditOrDeleteGame");
        }

        [HttpGet]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            Game game = await _uow.GameRepository.GetById(id);
            if (game == null) return NotFound();
            _uow.GameRepository.Delete(game);
            await _uow.Save();
            return RedirectToAction("EditOrDeleteGame");
        }

        #endregion

        #region Create,Delete,Update Referee

        public IActionResult AddReferee()
        {
            return View();
        }
        public async Task<ActionResult<IEnumerable<Referee>>> EditOrDeleteReferee()
        {
            var referee = await _uow.RefereeRepository.GetAll().ToListAsync();
            return View(referee);
        }

        [HttpPost]
        public async Task<ActionResult<Referee>> AddReferee(Referee referee)
        {
            _uow.RefereeRepository.Create(referee);
            await _uow.Save();
            return RedirectToAction("AddReferee");
        }

        [HttpGet]
        public async Task<ActionResult<Referee>> EditReferee(int id)
        {
            var referee = await _uow.RefereeRepository.GetById(id);
            if (referee == null) return NotFound();
            return View(referee);
        }

        [HttpPost]
        public async Task<IActionResult> EditReferee(int id, Referee referee)
        {
            if (id != referee.RefereeId) return BadRequest();
            _uow.RefereeRepository.Update(referee);
            await _uow.Save();
            return RedirectToAction("EditOrDeleteReferee");
        }

        [HttpGet]
        public async Task<ActionResult<Referee>> DeleteReferee(int id)
        {
            Referee referee = await _uow.RefereeRepository.GetById(id);
            if (referee == null) return NotFound();
            _uow.RefereeRepository.Delete(referee);
            await _uow.Save();
            return RedirectToAction("EditOrDeleteReferee");
        }

        #endregion

        #region Create,Delete,Update Sponsor

        public IActionResult AddSponsor()
        {
            ViewBag.Teams = GetTeams();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Sponsor>> AddSponsor(AddSponsorViewModel vm)
        {
            //var fileName = UploadFile(vm);
            var sponsor = new Sponsor
            {
                Name = vm.Name,
                CompanyName = vm.CompanyName,
            };
            var id = await _sponsorRepository.Save(sponsor);
            List<TeamSponsor> teamSponsors = vm.Teams.Select(team => new TeamSponsor() { TeamId = team, SponsorId = id }).ToList();
            await _teamSponsorRepository.Save(teamSponsors);
            return RedirectToAction("AddSponsor");
        }

        //private string UploadFile(AddSponsorViewModel vm)
        //{
        //    string fileName = "";
        //    if (vm.SponsorImage != null)
        //    {
        //        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
        //        fileName = Guid.NewGuid().ToString() + "-" + vm.SponsorImage.FileName;
        //        string filePath = Path.Combine(uploadDir, fileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            vm.SponsorImage.CopyTo(fileStream);
        //        }
        //    }
        //    return fileName;
        //}

        public async Task<ActionResult<IEnumerable<Sponsor>>> EditOrDeleteSponsor()
        {
            var sponsor = await _uow.SponsorRepository.GetAll().Include(x=>x.TeamSponsors).ThenInclude(x=>x.Team).ToListAsync();
            return View(sponsor);
        }
        
        public async Task<IActionResult> EditSponsor(int? id)
        {
            ViewBag.Teams = GetTeams();
            if (id == null)
                return NotFound();
            var sponsor = await _context.Sponsors.FindAsync(id);
            if (sponsor == null) 
                return NotFound();
            EditSponsorViewModel viewModel = new EditSponsorViewModel()
            {
                SponsorId = sponsor.SponsorId,
                Name = sponsor.Name,
                CompanyName = sponsor.CompanyName,
                Teams = new List<int> { sponsor.TeamSponsors.Count }
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditSponsor(int id, Sponsor sponsor)
        {
            if (id != sponsor.SponsorId) return BadRequest();
            _uow.SponsorRepository.Update(sponsor);
            await _uow.Save();
            return RedirectToAction("EditOrDeleteSponsor");
        }

        [HttpGet]
        public async Task<ActionResult<Sponsor>> DeleteSponsor(int id)
        {
            Sponsor sponsor = await _uow.SponsorRepository.GetById(id);
            if (sponsor == null) return NotFound();
            _uow.SponsorRepository.Delete(sponsor);
            await _uow.Save();
            return RedirectToAction("EditOrDeleteSponsor");
        }

        #endregion

        private SelectList GetTeams()
        {
            var teams = _uow.TeamRepository.GetAll().ToDictionary(t => t.TeamId, t => t.Name);
            teams.Add(-1, "-- Selecteer een team --");
            var list = new SelectList(teams.OrderBy(x => x.Key), "Key", "Value");
            return list;
        }
        private SelectList GetReferees()
        {
            var referees = _uow.RefereeRepository.GetAll().ToDictionary(r => r.RefereeId, r => r.Name);
            referees.Add(-1, "-- Selecteer een scheidsrechter --");
            var list = new SelectList(referees.OrderBy(x => x.Key), "Key", "Value");
            return list;
        }
    }
}
