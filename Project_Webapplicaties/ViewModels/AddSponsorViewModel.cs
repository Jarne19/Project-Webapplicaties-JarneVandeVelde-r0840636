using System.Collections.Generic;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.ViewModels
{
    public class AddSponsorViewModel
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public ICollection<TeamSponsor> TeamSponsors { get; set; }
    }
}
