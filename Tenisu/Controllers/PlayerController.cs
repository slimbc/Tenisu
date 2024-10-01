using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tenisu.Application.Interfaces;
using Tenisu.Domain.DTO;
using Tenisu.Domain.Entities;
using Tenisu.Infrastructure.Repositories;

namespace Tenisu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("This controller provides endpoints to manage tennis players.")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(IPlayerService playerService, ILogger<PlayerController> logger)
        {
            _playerService = playerService;
            _logger = logger;
        }



        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieve all players",
            Description = "Gets a list of all tennis players from the system.",
            OperationId = "GetAllPlayers",
            Tags = new[] { "Players" })]
        [SwaggerResponse(StatusCodes.Status200OK, "List of players retrieved successfully", typeof(IEnumerable<Player>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public IActionResult GetAllPlayers()
        {
            try
            {
                var players = _playerService.GetAllPlayers();
                return Ok(players);
            }
            catch(Exception ex)
            {
                _logger.LogError($"An unexpected error occurred: {ex}");
                return StatusCode(500, new { Code = 500, Message = "An unexpected error occurred." });
            }
           
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
           Summary = "Retrieve player by ID",
           Description = "Gets a tennis player by their unique ID.",
           OperationId = "GetPlayerById",
           Tags = new[] { "Players" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Player retrieved successfully", typeof(Player))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Player not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public IActionResult GetPlayerById(int id)
        {
            try
            {
                var player = _playerService.GetPlayerById(id);
                if (player == null)
                {
                    return NotFound(new { Code = 404, Message = $"Player with ID {id} not found." });
                }

                return Ok(player);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred: {ex}");
                return StatusCode(500, new { Code = 500, Message = "An unexpected error occurred." });
            }
        }

        [HttpGet("statistics")]
        [SwaggerOperation(
         Summary = "Get players statistics",
         Description = "Returns statistics including the country with the highest win ratio, the average BMI of all players, and the median height of all players.",
         OperationId = "GetPlayerStatistics",
         Tags = new[] { "Players" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Statistics retrieved successfully", typeof(PlayerStatistics))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public IActionResult GetStatistics()
        {
            try
            {
                var statistics = _playerService.GetStatistics();
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred: {ex}");
                return StatusCode(500, new { Code = 500, Message = "An unexpected error occurred." });
            }
        }
    }
}
