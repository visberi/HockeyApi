using System;
using System.Collections.Generic;
using PlayerService.DataModel;
using Xunit;

namespace PlayerService.UnitTests
{
    public class TeamTests
    {
        private Team testTeam;
        private const string DefaultPlayerName = "Test Player";
        private const string TestTeamName = "Test Team";
        public TeamTests()
        {
            List<Player> testPlayers = new List<Player> {new Player(DefaultPlayerName, 1, PlayerPosition.Center)};
            testTeam = new Team(TestTeamName, testPlayers);
        }

        [Fact]
        private void CreateTeam_WithPlayerList_InitializesPlayers()
        {
            Assert.Single(testTeam.Players);
        }

        [Fact]
        private void CreateTeam_DefaultPlayersParameter_InitializesEmptyPlayers()
        {
            Team testTeamNoPlayers = new Team(TestTeamName); // Invoke constructor with default null parameter for players IEnumerable
            Assert.Empty(testTeamNoPlayers.Players);
        }


        [Fact]
        private void AddPlayer_PlayerAdded()
        {
              testTeam.AddPlayer((new Player(DefaultPlayerName, 2, PlayerPosition.Goaltender)));
              Assert.Equal(2, testTeam.Players.Count);
              Assert.Equal(PlayerPosition.Goaltender, testTeam.Players[1].PlayerPosition);
        }

        [Fact]
        private void AddPlayerWithExistingNumber_ThrowsInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testTeam.AddPlayer(new Player(DefaultPlayerName, 1, PlayerPosition.Goaltender));
            });
        }

    }
}
