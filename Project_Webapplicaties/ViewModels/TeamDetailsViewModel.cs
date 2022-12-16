using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.Models;
using Project_Webapplicaties.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Project_Webapplicaties.ViewModels
{
    public class TeamDetailsViewModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public DivisionEnum Division { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
