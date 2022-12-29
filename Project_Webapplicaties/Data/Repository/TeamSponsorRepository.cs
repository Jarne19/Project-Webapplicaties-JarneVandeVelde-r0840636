using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.Repository
{
    public class TeamSponsorRepository : ITeamSponsorRepository
    {
        private readonly VwGerheideContext _context;

        public TeamSponsorRepository(VwGerheideContext context)
        {
            _context = context;
        }

        public async Task Save(List<TeamSponsor> teamSponsors)
        {
            await _context.TeamSponsors.AddRangeAsync(teamSponsors);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TeamSponsor>> GetBySponsor(int i)
        {
            return await _context.TeamSponsors.Include(t=>t.Team)
                .Where(t => t.SponsorId == i).ToListAsync();
        }
    }
}
