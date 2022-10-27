using System.Collections.Generic;

namespace Project_Webapplicaties.Models
{
    public class Sponsor
    {
        public int SponsorId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }

        public ICollection<TeamSponsor> TeamSponsors { get; set; }
    }
}
