using Tenisu.Application.Interfaces;
using Tenisu.Domain.DTO;
using Tenisu.Domain.Entities;
using Tenisu.Domain.Interfaces;
using Tenisu.Infrastructure.Repositories;

namespace Tenisu.Application.Services
{
    public class PlayerService : IPlayerService
    {

        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public List<Player> GetAllPlayers()
        {
            return _repository.GetAllPlayers();
        }

        public Player GetPlayerById(int id)
        {
            return _repository.GetPlayerById(id);
        }

        public PlayerStatistics GetStatistics()
        {
            var players = _repository.GetAllPlayers();


            var countryWithHighestWinRatio = players
                .GroupBy(p => p.Country.Code)
                .Select(g => new
                {
                    Country = g.Key,
                    WinRatio = g.Sum(p => p.Data.Last.Count(l => l == 1)) / (double)g.Sum(p => p.Data.Last.Count())
                })
                .OrderByDescending(c => c.WinRatio)
                .FirstOrDefault();

            var averageBMI = players
                .Average(p => p.Data.Weight / Math.Pow(p.Data.Height / 100.0, 2));

            var sortedHeights = players
                .Select(p => p.Data.Height)
                .OrderBy(h => h)
                .ToList();

            double medianHeight;
            int count = sortedHeights.Count;
            if (count % 2 == 0)
            {
                medianHeight = (sortedHeights[count / 2 - 1] + sortedHeights[count / 2]) / 2.0;
            }
            else
            {
                medianHeight = sortedHeights[count / 2];
            }

            return new PlayerStatistics
            {
                CountryWithHighestWinRatio = countryWithHighestWinRatio?.Country?? "",
                WinRatio = countryWithHighestWinRatio?.WinRatio ?? 0,
                AverageBMI = averageBMI,
                MedianHeight = medianHeight
            };
        }
    }
}
