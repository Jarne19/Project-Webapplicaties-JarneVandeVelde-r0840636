using System.Collections.Generic;
using System.Linq;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly VwGerheideContext _context;

        public PlayerRepository(VwGerheideContext context)
        {
            _context = context;
        }

        public Player Add(Player player)
        {
            return _context.Players.Add(player).Entity;
        }

        public Player Find(int playerId)
        {
            return _context.Players.Find(playerId);
        }

        public IEnumerable<Player> All()
        {
            return _context.Players.ToList();
        }

        public IQueryable<Player> Search()
        {
            return _context.Players.AsQueryable();
        }
    }
}
