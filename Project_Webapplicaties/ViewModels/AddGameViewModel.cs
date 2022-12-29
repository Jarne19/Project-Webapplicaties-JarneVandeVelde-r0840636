using Project_Webapplicaties.Models.Enums;
using System;

namespace Project_Webapplicaties.ViewModels
{
    public class AddGameViewModel
    {
        public DateTime PlayDate { get; set; }
        public int HomeTeam { get; set; }
        public TeamsEnum AwayTeam { get; set; }
        public int RefereeId { get; set; }
    }
}
