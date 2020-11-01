using System;
using System.Net;
using HockeyApi.Contracts;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HockeyApi.Controllers
{
    /// <summary>
    /// Exception handler, boilerplate taken from
    /// https://stackoverflow.com/questions/38630076/asp-net-core-web-api-exception-handling on 1st Nov 2020
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private ILogger<ErrorController> _logger;
        ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("error")]
        public IActionResult Error()
        {
 
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error; // Your exception

            // 404 Not Found result is thrown if invalid page is being searched
            // Other exceptions produce 500 Internal Error
            IActionResult result;
            if (exception is InvalidPageException)
            {
                result = new NotFoundResult();
            }
            else
            {
                result = new StatusCodeResult( (int)HttpStatusCode.InternalServerError);
            }

            _logger.LogError(String.Format("Error occurred: {0}", exception.Message));
          
            return result; // Your error model
        }
    }
}