using Tenisu.Domain.DTO;
using Tenisu.Domain.Entities;

namespace Tenisu.Application.Interfaces
{
    public interface IPlayerService
    {
        List<Player> GetAllPlayers();
        Player GetPlayerById(int id);
        PlayerStatistics GetStatistics();

    }
}
