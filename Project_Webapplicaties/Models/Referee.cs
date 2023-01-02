using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_Webapplicaties.Models
{
    public class Referee
    {
        public int RefereeId { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birtdate { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
