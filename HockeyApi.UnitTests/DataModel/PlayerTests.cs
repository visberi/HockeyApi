using System;
using HockeyApi.DataModel;
using Xunit;

namespace HockeyApi.UnitTests
{
    public class PlayerTests
    {
        private const string DefaultName = "Test Person";

        private const string DefaultTeam = "TestTeam";
        [Fact]
        public void ValidPlayerCreated_Succeeds()
        {
            Player testPlayer = new Player(DefaultName, 1, PlayerPosition.C, DefaultTeam);
            Assert.Equal(1 , testPlayer.PlayerNumber);
            Assert.Equal(PlayerPosition.C, testPlayer.PlayerPosition);
            Assert.Equal(DefaultName, testPlayer.Name);
            Assert.Equal(DefaultTeam, testPlayer.Team);
            Assert.Equal("C", testPlayer.PlayerPositionString);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void InvalidPlayerNumber_ThrowsArgumentOutOfRange(int playerNumber)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
            {
               new Player(DefaultName, playerNumber, PlayerPosition.C, DefaultTeam);
            });
        }
    }
}
