using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using PlayerService.Contracts;
using PlayerService.Controllers;
using PlayerService.Data;
using PlayerService.DataModel;
using PlayerService.UnitTests.Properties;
using Xunit;

namespace PlayerService.UnitTests.Controllers
{
    public class TeamControllerTest
    {
        private  TeamController _controller = new TeamController();

        public TeamControllerTest()
        {
            PlayerRepository.InitializePlayerDataFromCsv(Resources.ControllerTestData);
        }

        [Theory]
        [InlineData("Team 1", 2, 3, 29, 5)]
        [InlineData("Team 3",1, 3, 15, 5)]
        [InlineData("Team 4", 1, 0, 4, 4)]
        private void TeamPlayers_SortedCorrectly(string team, int pageNumber, int indexOnPage, int expectedPlayerNumberOnPage, int expectedPlayerCount)
        {
            ActionResult result = _controller.Get(team, new PaginationParameters(10,pageNumber));

            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);

            PaginatedResponse<Player> responseData = okResult.Value as PaginatedResponse<Player>;

            Assert.NotNull(responseData);

            Assert.Equal(expectedPlayerCount, responseData.Data.Count());

            Assert.Equal(expectedPlayerNumberOnPage, responseData.Data.ToList()[indexOnPage].PlayerNumber);
        }

        [Fact]
        private void NonExistentTeam_Returns200AndEmptySet()
        {
            ActionResult result = _controller.Get("Team Nonexistent", new PaginationParameters(10,1));

            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);

            PaginatedResponse<Player> responseData = okResult.Value as PaginatedResponse<Player>;

            Assert.NotNull(responseData);

            Assert.Empty(responseData.Data);
        }

    }
}
