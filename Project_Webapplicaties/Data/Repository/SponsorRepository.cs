using System.Threading.Tasks;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.Repository
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly VwGerheideContext _context;

        public SponsorRepository(VwGerheideContext context)
        {
            _context = context;
        }

        public async Task<int> Save(Sponsor entity)
        {
           await _context.Sponsors.AddAsync(entity); 
           await _context.SaveChangesAsync();
           return entity.SponsorId;
        }
    }
}
