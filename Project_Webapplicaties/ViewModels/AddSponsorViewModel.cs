using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.ViewModels
{
    public class AddSponsorViewModel
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public IFormFile SponsorImage { get; set; }
        public ICollection<TeamSponsor> TeamSponsors { get; set; }
    }
}
