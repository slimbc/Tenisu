using Tenisu.Domain.Entities;

namespace Tenisu.Domain.Interfaces
{
    public interface IPlayerRepository 
    {
        List<Player> GetAllPlayers();

        Player GetPlayerById(int id);

    }
}
