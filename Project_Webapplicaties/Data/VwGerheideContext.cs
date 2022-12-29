using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data
{
    public class VwGerheideContext : IdentityDbContext<IdentityUser>
    {
        public VwGerheideContext(DbContextOptions<VwGerheideContext> options):base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSponsor> TeamSponsors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().ToTable("Player")
                .HasOne(t=>t.Team)
                .WithMany(p=>p.Players)
                .HasForeignKey(t=>t.PloegId);
            modelBuilder.Entity<Game>().ToTable("Game")
                .HasOne(x => x.Team)
                .WithMany(p => p.Games)
                .HasForeignKey(x => x.HomeTeam);
            modelBuilder.Entity<Referee>().ToTable("Referee")
                .HasMany(x=>x.Games)
                .WithOne(x=>x.Referee)
                .HasForeignKey(x=>x.RefereeId);
            modelBuilder.Entity<Sponsor>().ToTable("Sponsor");
            modelBuilder.Entity<Team>().ToTable("Team")
                .HasMany(x=>x.Players)
                .WithOne(x=>x.Team)
                .HasForeignKey(x=>x.PloegId);
            modelBuilder.Entity<TeamSponsor>().ToTable("TeamSponsor");
        }
    }
}
