using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HockeyApi.Contracts;
using Xunit;

namespace HockeyApi.UnitTests
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
        private void PageSizeZero_SetToTen()
        {
            paginationParameters = new PaginationParameters(0, 1);
            PaginatedResponse<int> paginatedResponse = new PaginatedResponse<int>(data,paginationParameters);
            Assert.Equal(10, paginationParameters.PageSize);
        }

        [Fact]
        private void DefaultDataThirdPage_HasFiveItems()
        {
            PaginationParameters paginationParameters = new PaginationParameters(10,3);
            PaginatedResponse<int> paginatedResponse = new PaginatedResponse<int>(data,paginationParameters);
            Assert.Equal(5,paginatedResponse.Data.Count());
        }

        [Fact]
        private void DefaultDataFirstPageLast_EqualsToNine()
        {
            PaginatedResponse<int> paginatedResponse = new PaginatedResponse<int>(data,paginationParameters);
            Assert.Equal(9, paginatedResponse.Data.ToList()[9]);
        }

        [Fact]
        private void PageOverMaximum_ThrowsInvalidPageException()
        { 
            paginationParameters = new PaginationParameters(10, 4);
            Assert.Throws<InvalidPageException>(()
                => new PaginatedResponse<int>(data, paginationParameters));
        }

        [Fact]
        private void PageUnderZero_ThrowsInvalidPageException()
        {
            paginationParameters = new PaginationParameters(10, -1);
            Assert.Throws<InvalidPageException>(() =>
            
                new PaginatedResponse<int>(data, paginationParameters));
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
