using Project_Webapplicaties.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Webapplicaties.ViewModels
{
    public class AddGameViewModel
    {
        [Required(ErrorMessage = "Speel datum is verplicht")]
        public DateTime PlayDate { get; set; }
        [Required(ErrorMessage = "Thuis team is verplicht")]
        public int HomeTeam { get; set; }
        [Required(ErrorMessage = "Uit team is verplicht")]
        public TeamsEnum AwayTeam { get; set; }
        [Required(ErrorMessage = "Scheidsrechter is verplicht")]
        public int RefereeId { get; set; }
    }
}
