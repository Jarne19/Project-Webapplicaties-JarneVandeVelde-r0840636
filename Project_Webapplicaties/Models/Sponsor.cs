﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Project_Webapplicaties.Models
{
    public class Sponsor
    {
        public int SponsorId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }

        [ForeignKey(nameof(SponsorId))]
        public virtual ICollection<TeamSponsor>TeamSponsors { get; set; }
    }
}
