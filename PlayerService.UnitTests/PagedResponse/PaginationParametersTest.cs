using System;
using System.Collections.Generic;
using System.Text;
using PlayerService.Controllers;
using Xunit;

namespace PlayerService.UnitTests
{
    public class PaginationParametersTest
    {
        [Fact]
        private void NewParamsPageSizeOverMax_SetToMaxSize()
        {
            var paginationParameters = new PaginationParameters(856, 2);
            Assert.Equal(PaginationParameters.MaxPageSize, paginationParameters.PageSize);
        }

        [Fact]
        private void NewParamsPageSizeZero_SetToMinimumSize()
        {
            var paginationParameters = new PaginationParameters(0, 2);
            Assert.Equal(PaginationParameters.MinPageSize, paginationParameters.PageSize);
        }
    }
}
