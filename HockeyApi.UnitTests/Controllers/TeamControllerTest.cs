﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HockeyApi.Contracts;
using HockeyApi.Controllers;
using HockeyApi.Data;
using HockeyApi.DataModel;
using HockeyApi.Services;
using HockeyApi.UnitTests.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace HockeyApi.UnitTests
{
    public class TeamControllerTest
    {

        private TeamController _controller;

        public TeamControllerTest()
        {
            PlayerRepository.InitializePlayerDataFromCsv(Resources.ControllerTestData);
            ILoggerFactory mockFactory = new NullLoggerFactory();
            _controller = new TeamController(mockFactory.CreateLogger<TeamController>(), new PlayerService());
        }

        [Theory]
        [InlineData("Team 1", 2, 3, 29, 5)]
        [InlineData("Team 3",1, 3, 15, 5)]
        [InlineData("Team 4", 1, 0, 4, 4)]
        private void TeamPlayers_SortedCorrectly(string team, int pageNumber, int indexOnPage, int expectedPlayerNumberOnPage, int expectedPlayerCount)
        {
            ActionResult result = _controller.Get(team, 10,pageNumber);

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
            ActionResult result = _controller.Get("Team Nonexistent", 10,1);

            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);

            PaginatedResponse<Player> responseData = okResult.Value as PaginatedResponse<Player>;

            Assert.NotNull(responseData);

            Assert.Empty(responseData.Data);
        }
    }
}
