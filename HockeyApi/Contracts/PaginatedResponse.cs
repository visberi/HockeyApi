using System;
using System.Collections.Generic;
using System.Linq;

namespace HockeyApi.Contracts
{
    /// <summary>
    /// Implement minimal offset pagination implementation
    /// </summary>
    public class PaginatedResponse<T>
    {
        /// <summary>
        /// Create a new response. Sets properties of pageInfo based on nonPaginatedData.
        /// </summary>
        /// <param name="nonPaginatedData"></param>
        /// <param name="pageInfo"></param>
        /// <exception cref="InvalidPageException">Thrown if current page is outside of range of available pages.</exception>
        public PaginatedResponse (IEnumerable<T> nonPaginatedData, PaginationParameters pageInfo)
        {
            NonPaginatedData = nonPaginatedData.ToList();
 
            PaginationInfo = pageInfo;

            int lastPage = GetLastPageNumber(nonPaginatedData, pageInfo.PageSize);

            if ((pageInfo.CurrentPage > lastPage || pageInfo.CurrentPage < PaginationParameters.ValueNotSet) && NonPaginatedData.Any())
            {
                throw  new InvalidPageException(String.Format("Invalid page {0} does not exist.", pageInfo.CurrentPage));
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

        private static int GetLastPageNumber(IEnumerable<T> data, int pageSize)
        {
            return Convert.ToInt32(Math.Ceiling( data.Count() / Convert.ToDecimal(pageSize)));
        }
    }
}
