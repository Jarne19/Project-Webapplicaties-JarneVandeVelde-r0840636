using System.ComponentModel.DataAnnotations;
using Project_Webapplicaties.Models.Enums;

namespace Project_Webapplicaties.ViewModels
{
    public class AddTeamViewModel
    {
        [Required(ErrorMessage = "Team naam is verplicht")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Divisie is verplicht")]
        public DivisionEnum Division { get; set; }
    }
}
