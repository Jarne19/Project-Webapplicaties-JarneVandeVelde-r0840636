namespace Project_Webapplicaties.Models
{
    public class TeamSponsor
    {
        public int TeamSponsorId { get; set; }
        public int TeamId { get; set; }
        public int SponsorId { get; set; }

        public Team Team { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
