using System;

namespace Project_Webapplicaties.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public DateTime PlayDate { get; set; }
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
        public int RefereeId { get; set; }


        public Referee Referee { get; set; }
        public Team Team { get; set; }
    }
}
