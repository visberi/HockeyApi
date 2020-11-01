using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PlayerService.Contracts;
using PlayerService.Controllers;
using PlayerService.Data;
using PlayerService.DataModel;
using PlayerService.UnitTests.Properties;
using Xunit;

namespace PlayerService.UnitTests
{
    public class PlayerControllerTest
    {
        private PlayerController _controller;

        public PlayerControllerTest()
        {
            PlayerRepository.InitializePlayerDataFromCsv(Resources.ControllerTestData);
            ILoggerFactory mockFactory = new NullLoggerFactory();
            _controller = new PlayerController(mockFactory.CreateLogger<PlayerController>(), new Services.PlayerService());
        }

        /// <summary>
        /// Check that given player is on page at given index position
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="indexOnPage"></param>
        /// <param name="expectedPlayerName"></param>
        [Theory]
        [InlineData(1, 1, "Player13")]
        [InlineData(2, 3, "Player29")]
        [InlineData(2, 7, "Player10")]
        public void Player_AtCorrectLocation( int pageNumber, int indexOnPage, string expectedPlayerName)
        {
            ActionResult result = _controller.Get(10,pageNumber);

            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);

            PaginatedResponse<Player> responseData = okResult.Value as PaginatedResponse<Player>;

            Assert.NotNull(responseData);

            Assert.Equal(expectedPlayerName, responseData.Data.ToList()[indexOnPage].Name);
        }
    }
}
