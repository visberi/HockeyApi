using System;
using System.Collections.Generic;
using System.Text;
using HockeyApi.Data;
using HockeyApi.UnitTests.Properties;
using Xunit;

namespace HockeyApi.UnitTests
{
    public class PlayerRepositoryTest
    {
        /// <summary>
        /// Invalid data has two players with same number in same team.
        /// </summary>
        [Fact]
        private  void InvalidData_ThrowsExceptionOnInitialize()
        {
            Assert.Throws<InvalidOperationException>( () =>
                PlayerRepository.InitializePlayerDataFromCsv(Resources.InvalidData));
        }
    }
}
