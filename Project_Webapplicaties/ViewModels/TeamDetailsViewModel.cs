using Project_Webapplicaties.Models;
using Project_Webapplicaties.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Project_Webapplicaties.ViewModels
{
    public class TeamDetailsViewModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public DivisionEnum Division { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Player> Players { get; set; }
        public List<Player> GetVerdedigers()
        {
            var verdedigers = Players.Where(x => x.Position == (PositionEnum)1).ToList();
            return verdedigers;
        }
        public List<Player> GetKeepers()
        {
            var keepers = Players.Where(x => x.Position == 0).ToList();
            return keepers;
        }
        public List<Player> GetMiddenvelders()
        {
            var middenvelders = Players.Where(x => x.Position == (PositionEnum)2).ToList();
            return middenvelders;
        }
        public List<Player> GetAanvallers()
        {
            var aanvallers = Players.Where(x => x.Position == (PositionEnum)3).ToList();
            return aanvallers;
        }
    }
}
