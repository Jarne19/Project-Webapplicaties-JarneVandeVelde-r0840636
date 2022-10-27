using System;
using System.Collections.Generic;

namespace Project_Webapplicaties.Models
{
    public class Referee
    {
        public int RefereeId { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public DateTime Birtdate { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
