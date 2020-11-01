using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using PlayerService.Controllers;

namespace PlayerService.Services
{
    /// <summary>
    /// A small service that provides URIs e.g. for pagination purposes.
    /// Making this non-static injectable service should be considered.
    /// </summary>
    public static class UriService
    {
        // Use ugly hard-coded strings here
        private static readonly string _baseUri = "https://localhost:5001/api";
        private static  string _playerPath = "/players";
        private static  string _teamPath = "/team";

        public static Uri GetTeamUri(string teamName)
        {
            string uri = QueryHelpers.AddQueryString(_baseUri, "name", teamName);
            return  new Uri(uri);
        }

        public static Uri GetPlayerUri()
        {
            string uri = String.Format("{0}{1}", _baseUri, _playerPath);

            return  new Uri(uri);
        }
    }
}
