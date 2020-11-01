using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApi.Contracts
{
    /// <summary>
    /// Exception depicting that invalid page number was given.
    /// </summary>
    public class InvalidPageException: InvalidOperationException
    {
        public InvalidPageException(string message): base(message)
        {

        }
    }
}
