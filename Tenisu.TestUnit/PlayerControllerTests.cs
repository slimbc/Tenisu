using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Controllers;
using Tenisu.Application.Interfaces;
using Tenisu.Domain.Entities;
using System.Collections.Generic;
using Tenisu.Domain.DTO;

namespace Tenisu.Tests
{
    public class PlayerControllerTests
    {
        private readonly Mock<IPlayerService> _mockPlayerService;
        private readonly Mock<ILogger<PlayerController>> _mockLogger;
        private readonly PlayerController _playerController;

        public PlayerControllerTests()
        {
            _mockPlayerService = new Mock<IPlayerService>();
            _mockLogger = new Mock<ILogger<PlayerController>>();
            _playerController = new PlayerController(_mockPlayerService.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetAllPlayers_ReturnsOkResult_WithListOfPlayers()
        {
            var players = new List<Player>
            {
                new Player { Id = 1, FirstName = "Novak", LastName = "Djokovic" },
                new Player { Id = 2, FirstName = "Rafael", LastName = "Nadal" }
            };
            _mockPlayerService.Setup(service => service.GetAllPlayers()).Returns(players);
            var result = _playerController.GetAllPlayers();
            var okResult = Assert.IsType<OkObjectResult>(result); 
            var returnValue = Assert.IsType<List<Player>>(okResult.Value); 
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void GetAllPlayers_WhenExceptionThrown_Returns500()
        {
            _mockPlayerService.Setup(service => service.GetAllPlayers()).Throws(new System.Exception("File connection failed"));
            var result = _playerController.GetAllPlayers();
            var statusCodeResult = Assert.IsType<ObjectResult>(result); 
            Assert.Equal(500, statusCodeResult.StatusCode); 
        }

        [Fact]
        public void GetPlayerById_ReturnsOkResult_WhenPlayerExists()
        {
            var playerId = 1;
            var player = new Player { Id = playerId, FirstName = "Novak", LastName = "Djokovic" };
            _mockPlayerService.Setup(service => service.GetPlayerById(playerId)).Returns(player);
            var result = _playerController.GetPlayerById(playerId);
            var okResult = Assert.IsType<OkObjectResult>(result); 
            var returnValue = Assert.IsType<Player>(okResult.Value); 
            Assert.Equal(playerId, returnValue.Id); 
        }
        [Fact]
        public void GetPlayerById_ReturnsNotFound_WhenPlayerDoesNotExist()
        {
            var playerId = 99; 
            _mockPlayerService.Setup(service => service.GetPlayerById(playerId)).Returns((Player)null);
            var result = _playerController.GetPlayerById(playerId);
            Assert.IsType<NotFoundObjectResult>(result); 
        }

        [Fact]
        public void GetPlayerById_WhenExceptionThrown_Returns500()
        {
            var playerId = 1;
            _mockPlayerService.Setup(service => service.GetPlayerById(playerId)).Throws(new System.Exception("File connection failed"));
            var result = _playerController.GetPlayerById(playerId);
            var statusCodeResult = Assert.IsType<ObjectResult>(result); // Vérifier que la réponse est de type "ObjectResult"
            Assert.Equal(500, statusCodeResult.StatusCode); // Vérifier que le code de statut est 500
        }

        [Fact]
        public void GetStatistics_ReturnsOkResult_WithStatistics()
        {
            var statistics = new PlayerStatistics
            {
                CountryWithHighestWinRatio = "SRB",
                WinRatio = 0.8,
                AverageBMI = 24.5,
                MedianHeight = 185
            };
            _mockPlayerService.Setup(service => service.GetStatistics()).Returns(statistics);
            var result = _playerController.GetStatistics();
            var okResult = Assert.IsType<OkObjectResult>(result); 
            var returnValue = Assert.IsType<PlayerStatistics>(okResult.Value); 
            Assert.Equal("SRB", returnValue.CountryWithHighestWinRatio); 
            Assert.Equal(0.8, returnValue.WinRatio); 
            Assert.Equal(24.5, returnValue.AverageBMI); 
            Assert.Equal(185, returnValue.MedianHeight); 
        }

        [Fact]
        public void GetStatistics_WhenExceptionThrown_Returns500()
        {
            _mockPlayerService.Setup(service => service.GetStatistics()).Throws(new System.Exception("File connection failed"));
            var result = _playerController.GetStatistics();
            var statusCodeResult = Assert.IsType<ObjectResult>(result); 
            Assert.Equal(500, statusCodeResult.StatusCode); 
        }

    }
}
