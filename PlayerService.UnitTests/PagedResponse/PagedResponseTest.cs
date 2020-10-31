using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerService.Contracts;
using PlayerService.Controllers;
using Xunit;

namespace PlayerService.UnitTests
{
    public  class PagedResponseTest
    {
        private List<int> data;
        private int defaultDataCount = 25;


        private PaginationParameters paginationParameters;
        public PagedResponseTest()
        {
            data = new List<int>();
            for (int i = 0; i < defaultDataCount; i++)
            {
                data.Add(i);
            }

            // Create default pagination parameters
            paginationParameters = new PaginationParameters();
        }

        [Fact]
        private void DefaultDataThirdPage_HasFiveItems()
        {
            paginationParameters = new PaginationParameters(10,3);
            PagedResponse<int> paginatedData = new PagedResponse<int>(data,paginationParameters);
            Assert.Equal(5,paginatedData.Data.Count());
        }

        [Fact]
        private void DefaultDataFirstPageLast_EqualsToNine()
        {
            PagedResponse<int> paginatedData = new PagedResponse<int>(data,paginationParameters);
            Assert.Equal(9, paginatedData.Data.ToList()[9]);
        }

        [Fact]
        private void EmptyData_ReturnsEmpty()
        {
            data.Clear();
            PagedResponse<int> paginatedData = new PagedResponse<int>(data,paginationParameters);
            Assert.Empty( paginatedData.Data);
        }
    }
}
