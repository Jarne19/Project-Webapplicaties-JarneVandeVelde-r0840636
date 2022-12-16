using Project_Webapplicaties.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project_Webapplicaties.ViewModels
{
    public class GameListViewModel
    {
        public List<Game> Games { get; set; }

        public List<Game> GetGames()
        {
            var game = Games.OrderBy(x=>x.PlayDate).Take(2).ToList();
            return game;
        }
    }
}
