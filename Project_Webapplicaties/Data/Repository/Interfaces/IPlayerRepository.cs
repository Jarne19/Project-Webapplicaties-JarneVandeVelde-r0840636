using System.Collections.Generic;
using System.Linq;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        Player Add(Player player);
        Player Find(int playerId);
        IEnumerable<Player> All();
        IQueryable<Player> Search();
    }
}
