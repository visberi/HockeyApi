using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerService.Controllers;

namespace PlayerService.Contracts
{
    public class PagedResponse<T>
    {
        #region Constructors
        public PagedResponse()
        {

        }

        public PagedResponse (IEnumerable<T> nonPaginatedData, PaginationParameters pageInfo)
        {
            NonPaginatedData = nonPaginatedData;
            PaginationInfo = pageInfo;
        }
        #endregion Constructors

        #region Private properties
        private IEnumerable<T> NonPaginatedData { get; set; }
        #endregion Private properties

        #region Public properties
        /// <summary>
        /// Data collection that shall be returned as part of response to the api caller
        /// </summary>
        public IEnumerable<T> Data => ApplyPagination(NonPaginatedData);


        public  PaginationParameters PaginationInfo { get; set; }
        public string NextPage { get; set; }
        public  string PreviousPage { get; set; }

        

        #endregion Public properties

        #region private methods
        private IEnumerable<T> ApplyPagination(IEnumerable<T> data)
        {
            return data.Skip((PaginationInfo.Page - 1) * PaginationInfo.PageSize).Take( PaginationInfo.PageSize);
        }
        
        #endregion private methods

    }
}
