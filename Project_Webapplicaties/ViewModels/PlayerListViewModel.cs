using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.ViewModels
{
    public class PlayerListViewModel
    {
        public string PlayerSearch { get; set; }
        public List<Player> Players { get; set; }
        public List<Player> GetVerdedigers()
        {
            var verdedigers = Players.Where(x => x.Position == (Models.Enums.PositionEnum)1).ToList();
            return verdedigers;
        }
    }
}
