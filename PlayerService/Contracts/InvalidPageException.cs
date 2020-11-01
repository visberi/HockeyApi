using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerService.Contracts
{
    public class InvalidPageException: InvalidOperationException
    {
        public InvalidPageException(string message): base(message)
        {

        }
    }
}
