using System.Collections.Generic;

namespace Project_Webapplicaties.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<TeamSponsor> TeamSponsors { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
