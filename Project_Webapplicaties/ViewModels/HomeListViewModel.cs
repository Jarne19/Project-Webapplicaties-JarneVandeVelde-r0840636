using System.Collections.Generic;
using System.Linq;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.ViewModels
{
    public class HomeListViewModel
    {
        private readonly TeamListViewModel _team;
        private readonly GameListViewModel _game;
        private readonly SponsorListViewModel _sponsor;

        public HomeListViewModel(TeamListViewModel team,GameListViewModel game,SponsorListViewModel sponsor)
        {
            _team = team;
            _game = game;
            _sponsor = sponsor;
        }
        public List<Game> GetGames()
        {
            var game = _game.Games.OrderBy(x => x.PlayDate).Take(2).ToList();
            return game;
        }
        public List<Team> GetTeams()
        {
            var team = _team.Teams.Take(3).ToList();
            return team;
        }

        public List<Sponsor> GetSponsors()
        {
            var sponsor = _sponsor.Sponsors.Take(3).ToList();
            return sponsor;
        }
    }
}
