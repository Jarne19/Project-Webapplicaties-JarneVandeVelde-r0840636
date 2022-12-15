using System.Threading.Tasks;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Player> PlayerRepository { get; }
        IGenericRepository<Team> TeamRepository { get; }
        Task Save();
    }
}
