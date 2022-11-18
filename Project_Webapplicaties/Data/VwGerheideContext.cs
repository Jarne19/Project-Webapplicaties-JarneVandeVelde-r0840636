﻿using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data
{
    public class VwGerheideContext : DbContext
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
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Referee>().ToTable("Referee");
            modelBuilder.Entity<Sponsor>().ToTable("Sponsor");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<TeamSponsor>().ToTable("TeamSponsor");
        }
    }
}