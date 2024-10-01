using System.Text.Json.Serialization;

namespace Tenisu.Domain.Entities
{
    public  class PlayersRoot
    {
        [JsonPropertyName("players")]
        public List<Player> Players { get; set; }
    }
}
