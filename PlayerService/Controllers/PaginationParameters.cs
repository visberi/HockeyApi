using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PlayerService.Controllers
{
    /// <summary>
    /// A container class to for pagination information to implement simple pagination
    /// </summary>
    public class PaginationParameters
    {
        public PaginationParameters()
        {

        }

        /// <summary>
        /// Create new pagination parameter object.
        /// </summary>
        /// <param name="pageSize">If value is more then MaxPageSize, MaxPageSize value is used instead.
        /// If value is less than MinPageSize, MinPageSiz is used instead.
        /// </param>
        /// <param name="currentPage">Page of data to be returned.
        /// If value is less than 1, page number 1 is used.
        /// </param>
        public PaginationParameters(int pageSize, int currentPage)
        {
            Page = currentPage;
            PageSize = pageSize;
        }

        public const int MaxPageSize = 50;
        public const int MinPageSize = 1;

        private int _pageSize = 10;
        private int _page = 1;

        public int Page
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;
        } 

        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < MinPageSize)
                {
                    _pageSize = MinPageSize;
                }
                else if (value > MaxPageSize)
                {
                    _pageSize = MaxPageSize;
                }
                else
                {
                    _pageSize = value;
                }
            } 
        }
    }
}
