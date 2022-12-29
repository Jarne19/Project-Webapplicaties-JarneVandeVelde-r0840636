using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.ViewModels
{
    public class AddSponsorViewModel
    {
        public AddSponsorViewModel()
        {
            Teams = new List<int>();
        }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public IFormFile SponsorImage { get; set; }
        public List<int> Teams { get; set; }
    }
}
