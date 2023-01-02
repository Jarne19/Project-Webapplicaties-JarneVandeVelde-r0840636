using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Webapplicaties.ViewModels
{
    public class AddRefereeViewModel
    {
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        public DateTime Birtdate { get; set; }
    }
}
