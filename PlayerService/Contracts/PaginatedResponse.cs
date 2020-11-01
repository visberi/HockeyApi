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
        /// <summary>
        /// Create a new response. Sets properties of pageInfo based on nonPaginatedData.
        /// Makes sanity check to current page given by pageInfo and if invalid page is given
        /// set page to last page of data.
        /// </summary>
        /// <param name="nonPaginatedData"></param>
        /// <param name="pageInfo"></param>
        public PaginatedResponse (IEnumerable<T> nonPaginatedData, PaginationParameters pageInfo)
        {
            NonPaginatedData = nonPaginatedData;
 
            PaginationInfo = pageInfo;

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
