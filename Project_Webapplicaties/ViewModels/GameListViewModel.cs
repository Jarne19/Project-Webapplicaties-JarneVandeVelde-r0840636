using Project_Webapplicaties.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project_Webapplicaties.ViewModels
{
    public class GameListViewModel
    {
        private readonly TeamListViewModel _team;

        public GameListViewModel(TeamListViewModel team)
        {
            _team = team;
        }

        public List<Game> Games { get; set; }

        public List<Game> GetGames()
        {
            var game = Games.OrderBy(x=>x.PlayDate).Take(2).ToList();
            return game;
        }
        public List<Team> GetTeams()
        {
            var team = _team.Teams.Take(3).ToList();
            return team;
        }
    }
}
