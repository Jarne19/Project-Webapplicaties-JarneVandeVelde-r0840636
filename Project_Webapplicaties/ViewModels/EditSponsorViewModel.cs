using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Project_Webapplicaties.ViewModels
{
    public class EditSponsorViewModel
    {
        public int SponsorId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public List<int> Teams { get; set; }
    }
}
