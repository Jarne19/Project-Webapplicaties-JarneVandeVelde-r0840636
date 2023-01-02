using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Project_Webapplicaties.Models.Enums;

namespace Project_Webapplicaties.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public DivisionEnum Division { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<Game> Games { get; set; }


        [ForeignKey(nameof(TeamId))]
        public virtual ICollection<TeamSponsor> TeamSponsors { get; set; }
    }
}
