using System;

namespace Project_Webapplicaties.ViewModels
{
    public class PlayerDetailsViewModel
    {
        public int PlayerId { get; set; }
        public string Firstname { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string PastDetails { get; set; }
        public string BestLeg { get; set; }
        public int? PloegId { get; set; }
    }
}
