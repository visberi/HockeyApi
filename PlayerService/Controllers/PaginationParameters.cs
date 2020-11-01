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

        public PaginationParameters(int pageSize, int currentPage)
        {
            Page = currentPage;
            PageSize = pageSize;
        }

        public const int MaxPageSize = 50;
        public const int MinPageSize = 1;
        public int Page { get; set; } = 1; // Default page number is 1
        private int _pageSize = 10; // Default page size is 10
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
