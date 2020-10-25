using System;
using System.Collections.Generic;
using PlayerService.DataModel;
using Xunit;

namespace PlayerService.UnitTests
{
    public class TeamTests
    {
        private Team testTeam;
        private const string defaultPlayerName = "Test Player";
        public TeamTests()
        {
            List<Player> testPlayers = new List<Player> {new Player(defaultPlayerName, 1, PlayerPosition.Center)};
            testTeam = new Team("Test Team", testPlayers);
        }

        [Fact]
        private void AddPlayer_Succeeds()
        {
              testTeam.AddPlayer((new Player(defaultPlayerName, 2, PlayerPosition.Goaltender)));
              Assert.Equal(2, testTeam.Players.Count);
        }

        [Fact]
        private void AddPlayerWithExistingNumber_ThrowsInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testTeam.AddPlayer(new Player(defaultPlayerName, 1, PlayerPosition.Goaltender));
            });
        }

    }
}
