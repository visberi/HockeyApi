using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.WebUtilities;
using PlayerService.Services;

namespace PlayerService.Contracts
{
    /// <summary>
    /// A container class to for pagination information to implement simple pagination
    /// </summary>
    public class PaginationParameters
    {
        public static int CurrentPageNotSet = 0;

        private const int DefaultPage = 1;

        public const int DefaultPageSize = 10;
        
        public const int MaxPageSize = 50;

        public const int MinPageSize = 1;

        /// <summary>
        /// Init with default values.
        /// </summary>
        public PaginationParameters()
        {
            _pageSize = 10;
            _currentPage = 1;
        }

        /// <summary>
        /// Create new pagination parameter object.
        /// </summary>
        /// <param name="pageSize">If value is more then MaxPageSize, MaxPageSize value is used instead.
        /// If value is zero (e.g. no parameter from api given), set to default value.
        /// </param>
        /// <param name="currentPage">CurrentPage of data to be returned.
        /// If value is 0, default page number is used instead.
        /// </param>
        public PaginationParameters(int pageSize, int currentPage)
        {
            PageSize = pageSize == CurrentPageNotSet ? DefaultPageSize : pageSize;

            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        private int _pageSize = 10;

        private int _currentPage = 1;

        public int CurrentPage
        {
            get => _currentPage;
            set => _currentPage = value == CurrentPageNotSet ? DefaultPage : value;
        }

        public Uri BaseUri { get; set; }

        public int TotalPageCount { get; set; }

        /// <summary>
        /// Size of the page limited by MinPageSize and MaxPageSize
        /// </summary>
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

        public Uri NextUri {
            get
            {
                if (CurrentPage == TotalPageCount)
                {
                    return null;
                }
                string uri = QueryHelpers.AddQueryString(BaseUri.ToString(), "CurrentPage", (CurrentPage + 1).ToString());
                uri = QueryHelpers.AddQueryString(uri, "PageSize", PageSize.ToString());
                return  new Uri(uri);
            }
        }
        public Uri PreviousUri
        {
            get
            {
                if (CurrentPage < 2)
                {
                    return null;
                }
                string uri = QueryHelpers.AddQueryString(BaseUri.ToString(), "CurrentPage", (CurrentPage - 1).ToString());
                uri = QueryHelpers.AddQueryString(uri, "PageSize", PageSize.ToString());
                return  new Uri(uri);
            }
        }
    }
}
