using System;
using System.ComponentModel.DataAnnotations;
using Project_Webapplicaties.Models.Enums;

namespace Project_Webapplicaties.ViewModels
{
    public class AddPlayerViewModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Positie is verplicht")]
        public PositionEnum Position { get; set; }
        [Required(ErrorMessage = "Beste been is verplicht")]
        public BestLegEnum BestLeg { get; set; }
        public int? PloegId { get; set; }

    }
}
