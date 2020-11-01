using Microsoft.AspNetCore.WebUtilities;

namespace HockeyApi.Contracts
{
    /// <summary>
    /// A container class to for pagination information to implement simple offset pagination
    /// </summary>
    public class PaginationParameters
    {
        public static int ValueNotSet = 0;

        private const int DefaultPage = 1;

        public const int DefaultPageSize = 10;
        
        public const int MaxPageSize = 50;

        public const int MinPageSize = 1;

        public PaginationParameters()
        {
            _pageSize = DefaultPageSize;
            _currentPage = DefaultPage;
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
            PageSize = pageSize == ValueNotSet ? DefaultPageSize : pageSize;

            CurrentPage = currentPage;
        }

        private int _pageSize;

        private int _currentPage;

        public int CurrentPage
        {
            get => _currentPage;
            set => _currentPage = value == ValueNotSet ? DefaultPage : value;
        }

        public string BaseUri { get; set; }

        public int TotalPageCount { get; set; }

        /// <summary>
        /// Size of the page limited by MinPageSize and MaxPageSize
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < ValueNotSet)
                {
                    _pageSize = DefaultPageSize;
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

        public string NextUri 
        {
            get
            {
                if (CurrentPage == TotalPageCount)
                {
                    return null;
                }
                string uri = QueryHelpers.AddQueryString(BaseUri.ToString(), "CurrentPage", (CurrentPage + 1).ToString());
                uri = QueryHelpers.AddQueryString(uri, "PageSize", PageSize.ToString());
                return uri;
            }
        }
      
        public string PreviousUri
        {
            get
            {
                if (CurrentPage < 2)
                {
                    return null;
                }
                string uri = QueryHelpers.AddQueryString(BaseUri.ToString(), "CurrentPage", (CurrentPage - 1).ToString());
                uri = QueryHelpers.AddQueryString(uri, "PageSize", PageSize.ToString());
                return uri;
            }
        }
    }
}
