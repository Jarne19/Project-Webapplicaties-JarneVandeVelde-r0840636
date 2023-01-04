using System.Collections.Generic;
using System.Linq;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.ViewModels
{
    public class PlayerListViewModel
    {
        public string PlayerSearch { get; set; }
        public List<Player> Players { get; set; }

        public List<Player> GetPlayers()
        {
            return Players.OrderBy(x=>x.Name).ToList();
        }

        public List<Player> GetVerdedigers()
        {
            return Players.Where(x => x.Position == (Models.Enums.PositionEnum)1).ToList();
        }
    }
}
