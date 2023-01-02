using System.Collections.Generic;
using System.Threading.Tasks;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.Repository.Interfaces
{
    public interface ITeamSponsorRepository
    {
        Task Save(List<TeamSponsor> teamSponsors);
        Task<List<TeamSponsor>> GetBySponsor(int i);
    }
}