using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayerService.Contracts;
using PlayerService.Data;
using PlayerService.DataModel;

namespace PlayerService.Controllers
{
    [Route("/api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private ILogger<TeamController> _logger;

        [HttpGet("{name}", Name = "Get")]
        public ActionResult Get(string name, int pageSize, int page)
        {
            PaginationParameters paginationParameters = new PaginationParameters(pageSize, page);

            var response = new PaginatedResponse<Player>(PlayerProvider.GetPlayersByTeam(name), paginationParameters) ;
            _logger.LogInformation("Successfully retrieved team data", response);
            return Ok(response);
        }
    }
}
