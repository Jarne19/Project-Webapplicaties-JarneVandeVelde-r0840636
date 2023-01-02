using System;
using System.ComponentModel.DataAnnotations;
using Project_Webapplicaties.Models;
using Project_Webapplicaties.Models.Enums;

namespace Project_Webapplicaties.ViewModels
{
    public class PlayerDetailsViewModel
    {
        public int PlayerId { get; set; }
        public string Firstname { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public PositionEnum Position { get; set; }
        public BestLegEnum BestLeg { get; set; }
        public int? PloegId { get; set; }
        public Team team { get; set; }
        public string GetFullName => $"{Firstname} {Name}";
        public int GetAge => DateTime.Now.Year - Birthdate.Year;
    }
}
