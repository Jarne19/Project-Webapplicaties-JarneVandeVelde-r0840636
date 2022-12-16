using System.Threading.Tasks;
using Project_Webapplicaties.Data.Repository;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VwGerheideContext _context;

        public UnitOfWork(VwGerheideContext context)
        {
            _context = context;
        }

        private IGenericRepository<Player> _playerRepository;

        public IGenericRepository<Player> PlayerRepository
        {
            get
            {
                if (_playerRepository == null)
                {
                    _playerRepository = new GenericRepository<Player>(_context);
                }
                return _playerRepository;
            }
        }
        private IGenericRepository<Team> _teamRepository;

        public IGenericRepository<Team> TeamRepository
        {
            get
            {
                if (_teamRepository == null)
                {
                    _teamRepository = new GenericRepository<Team>(_context);
                }

                return _teamRepository;
            }
        }
        private IGenericRepository<Game> _gameRepository;
        public IGenericRepository<Game> GameRepository
        {
            get
            {
                if(_gameRepository == null)
                {
                    _gameRepository = new GenericRepository<Game>(_context);
                }
                return _gameRepository;
            }
        }
        private IGenericRepository<Referee> _refereeRepository;
        public IGenericRepository<Referee> RefereeRepository
        {
            get
            {
                if (_refereeRepository == null)
                {
                    _refereeRepository = new GenericRepository<Referee>(_context);
                }
                return _refereeRepository;
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
