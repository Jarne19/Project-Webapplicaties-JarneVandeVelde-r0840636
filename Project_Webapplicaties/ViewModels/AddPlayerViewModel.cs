using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Webapplicaties.ViewModels
{
    public class AddPlayerViewModel
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Birth date is required")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Past details is required")]
        public string PastDetails { get; set; }
        [Required(ErrorMessage = "Best leg is required")]
        public string BestLeg { get; set; }
        public int? PloegId { get; set; }
    }
}
