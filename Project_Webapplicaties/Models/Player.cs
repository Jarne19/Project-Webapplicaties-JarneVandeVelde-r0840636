﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Webapplicaties.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Firstname { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string PastDetails { get; set; }
        public string BestLeg { get; set; }
        public int? PloegId { get; set; }

        public Team Team { get; set; }
    }
}
