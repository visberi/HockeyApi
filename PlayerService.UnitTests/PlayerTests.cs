using System;
using PlayerService.DataModel;
using Xunit;

namespace PlayerService.UnitTests
{
    public class PlayerTests
    {
        private const string DefaultName = "Test Person";
        [Fact]
        public void PlayerCreated()
        {
            Player testPlayer = new Player(DefaultName, 1, PlayerPosition.Center);
            Assert.Equal(1 , testPlayer.PlayerNumber);
            Assert.Equal(PlayerPosition.Center, testPlayer.PlayerPosition);
            Assert.Equal(DefaultName, testPlayer.Name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void InvalidPlayerNumberThrowsArgumentOutOfRange(int playerNumber)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
            {
               new Player(DefaultName, playerNumber, PlayerPosition.Center);
            });
        }

    }
}
