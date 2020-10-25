using System;
using PlayerService.DataModel;
using Xunit;

namespace PlayerService.UnitTests
{
    public class PlayerTests
    {
        private const string DefaultName = "Test Person";
        [Fact]
        public void ValidPlayerCreated_Succeeds()
        {
            Player testPlayer = new Player(DefaultName, 1, PlayerPosition.C);
            Assert.Equal(1 , testPlayer.PlayerNumber);
            Assert.Equal(PlayerPosition.C, testPlayer.PlayerPosition);
            Assert.Equal(DefaultName, testPlayer.Name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void InvalidPlayerNumber_ThrowsArgumentOutOfRange(int playerNumber)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
            {
               new Player(DefaultName, playerNumber, PlayerPosition.C);
            });
        }

    }
}
