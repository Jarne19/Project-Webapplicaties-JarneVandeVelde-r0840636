using Project_Webapplicaties.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Webapplicaties.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [DataType(DataType.Date)]
        public DateTime PlayDate { get; set; }
        public int HomeTeam { get; set; }
        public TeamsEnum AwayTeam { get; set; }
        public int RefereeId { get; set; }


        public Referee Referee { get; set; }
        public Team Team { get; set; }
    }
}
