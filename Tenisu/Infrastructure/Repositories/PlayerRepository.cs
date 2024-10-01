using System.Net.Http.Json;
using Tenisu.Domain.Entities;
using Tenisu.Domain.Interfaces;
using Tenisu.Infrastructure.Context;

namespace Tenisu.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PlayerContext _context;

        public PlayerRepository(PlayerContext context)
        {
            _context = context;
        }

        public List<Player> GetAllPlayers()
        {
            return _context.GetPlayers();
        }

        public Player? GetPlayerById(int id)
        {
            return _context.GetPlayers().FirstOrDefault(p => p.Id == id);
        }
    }
}
