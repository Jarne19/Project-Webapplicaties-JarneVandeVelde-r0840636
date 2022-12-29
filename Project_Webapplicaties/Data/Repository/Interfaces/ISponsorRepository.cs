using System.Threading.Tasks;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.Repository.Interfaces
{
    public interface ISponsorRepository
    {
        Task<int> Save(Sponsor entity);
    }
}