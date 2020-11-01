using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerService.Contracts;
using PlayerService.Controllers;
using Xunit;

namespace PlayerService.UnitTests
{
    public  class PaginatedResponseTest
    {
        private List<int> data;
        private int defaultDataCount = 25;


        private PaginationParameters paginationParameters;
        public PaginatedResponseTest()
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
            PaginatedResponse<int> paginatedData = new PaginatedResponse<int>(data,paginationParameters);
            Assert.Equal(5,paginatedData.Data.Count());
        }

        [Fact]
        private void DefaultDataFirstPageLast_EqualsToNine()
        {
            PaginatedResponse<int> paginatedData = new PaginatedResponse<int>(data,paginationParameters);
            Assert.Equal(9, paginatedData.Data.ToList()[9]);
        }

        [Fact]
        private void PageOverMaximum_ReturnsLastPage()
        { 
            paginationParameters = new PaginationParameters(10, 4);
            PaginatedResponse<int> paginatedData = new PaginatedResponse<int>(data, paginationParameters);
            Assert.Equal(3, paginatedData.PaginationInfo.Page);
        }

        [Fact]
        private void EmptyData_ReturnsEmpty()
        {
            data.Clear();
            PaginatedResponse<int> paginatedData = new PaginatedResponse<int>(data,paginationParameters);
            Assert.Empty( paginatedData.Data);
        }
    }
}
