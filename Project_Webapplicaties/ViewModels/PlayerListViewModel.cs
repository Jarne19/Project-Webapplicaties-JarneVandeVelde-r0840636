using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.ViewModels
{
    public class PlayerListViewModel
    {
        public string PlayerSearch { get; set; }
        public List<Player> Players { get; set; }
    }
}
