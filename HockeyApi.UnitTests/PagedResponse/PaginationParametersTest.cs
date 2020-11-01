using System;
using System.Collections.Generic;
using System.Text;
using HockeyApi.Contracts;
using Xunit;

namespace HockeyApi.UnitTests
{
    public class PaginationParametersTest
    {
        [Fact]
        private void PageSizeOverMax_SetToMaxSize()
        {
            PaginationParameters paginationParameters = new PaginationParameters(856, 2);
            Assert.Equal(PaginationParameters.MaxPageSize, paginationParameters.PageSize);
        }

        [Fact]
        private void PageSizeZero_SetToDefaultSize()
        {
            PaginationParameters paginationParameters = new PaginationParameters(0, 2);
            Assert.Equal(PaginationParameters.DefaultPageSize, paginationParameters.PageSize);
        }

        [Fact]
        private void CurrentPageZero_SetToFirstPage()
        {
            PaginationParameters paginationParameters = new PaginationParameters(10, 0);
            Assert.Equal(1, paginationParameters.CurrentPage);
        }
    }
}
