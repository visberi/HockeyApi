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

        public PaginationParameters(uint pageSize, uint currentPage)
        {
            Page = currentPage;
            PageSize = pageSize;
        }

        public const uint MaxPageSize = 50;
        public const uint MinPageSize = 1;
        public uint Page { get; set; } = 1; // Default page number is 1
        private uint _pageSize = 10; // Default page size is 10
        public uint PageSize
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
