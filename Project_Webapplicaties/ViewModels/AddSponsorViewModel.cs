using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Project_Webapplicaties.ViewModels
{
    public class AddSponsorViewModel
    {
        public AddSponsorViewModel()
        {
            Teams = new List<int>();
        }
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Naam van bedrijf is verplicht")]
        public string CompanyName { get; set; }

        public string Image { get; set; }
        public IFormFile SponsorImage { get; set; }
        public List<int> Teams { get; set; }
    }
}
