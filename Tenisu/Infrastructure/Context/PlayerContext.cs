using System.Text.Json;
using Tenisu.Domain.Entities;

namespace Tenisu.Infrastructure.Context
{
    public class PlayerContext
    {
        private  string _jsonFilePath;

        public PlayerContext()
        {
            _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "headtohead.json");
        }

        public List<Player> GetPlayers()
        {
            if (!File.Exists(_jsonFilePath))
                throw new FileNotFoundException("Le fichier JSON n'a pas été trouvé.");

            var jsonContent = File.ReadAllText(_jsonFilePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var playersRoot = JsonSerializer.Deserialize<PlayersRoot>(jsonContent,options);

            return playersRoot?.Players;
        }
    }
}
