using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerService.Controllers
{
    /// <summary>
    /// A container class to keep pagination related information
    /// </summary>
    public class PaginationParameters
    {
        const int MaxPageSize = 50;
        public int Page { get; set; } = 1; // Default page number is 1
        private int _pageSize = 10; // Default page size is 10
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
