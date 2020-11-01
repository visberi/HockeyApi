using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerService.Controllers;
using PlayerService.DataModel;
using PlayerService.Services;

namespace PlayerService.Contracts
{
    /// <summary>
    /// Implement minimal offset pagination implementation
    /// </summary>
    public class PaginatedResponse<T>
    {
        public PaginatedResponse (IEnumerable<T> nonPaginatedData, PaginationParameters pageInfo)
        {
            NonPaginatedData = nonPaginatedData;
 
            PaginationInfo = pageInfo;

            // Set pagination information to reflect the state of data.

            // Check that the paging did not exceed the count of pages
            int lastPage = GetLastPageNumber(nonPaginatedData, pageInfo.PageSize);
            if (pageInfo.CurrentPage > lastPage)
            {
                pageInfo.CurrentPage = lastPage;
            }

            pageInfo.TotalPageCount = lastPage;
        }

        private IEnumerable<T> NonPaginatedData { get; set; }
        
        /// <summary>
        /// Data collection that shall be returned as part of response to the api caller
        /// </summary>
        public IEnumerable<T> Data => ApplyPagination(NonPaginatedData);

        public  PaginationParameters PaginationInfo { get; set; }

        private IEnumerable<T> ApplyPagination(IEnumerable<T> data)
        {
            return data.Skip( (int)( (PaginationInfo.CurrentPage - 1) * PaginationInfo.PageSize) ).Take( (int)PaginationInfo.PageSize);
        }

        /// <summary>
        /// Get last page number of the data.
        /// Due to usage of IEnumerable this causes an extra enumeration. Using another
        /// data structure should be considered.
        /// </summary>
        private static int GetLastPageNumber(IEnumerable<T> data, int pageSize)
        {
            return Convert.ToInt32(Math.Ceiling( data.Count() / Convert.ToDecimal(pageSize)));
        }
    }
}
