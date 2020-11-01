using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayerService.Contracts;
using PlayerService.Data;
using PlayerService.DataModel;
using PlayerService.Services;

namespace PlayerService.Controllers
{
    [Route("/api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public TeamController(ILogger<TeamController> logger, IPlayerService playerService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _playerService = playerService;
        }

        private ILogger<TeamController> _logger;

        private IPlayerService _playerService;

        [HttpGet]
        public ActionResult Get(string name, int pageSize, int page)
        {
            PaginationParameters paginationParameters = new PaginationParameters(pageSize, page);

            paginationParameters.BaseUri = UriService.GetTeamUri(name).AbsoluteUri;

            var response = new PaginatedResponse<Player>(_playerService.GetPlayersByTeam(name), paginationParameters) ;
            _logger.LogInformation("Successfully retrieved team data", response);
            return Ok(response);
        }
    }
}
