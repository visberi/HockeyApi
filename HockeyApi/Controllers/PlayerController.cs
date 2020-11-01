using System;
using HockeyApi.Contracts;
using HockeyApi.DataModel;
using HockeyApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HockeyApi.Controllers
{
    [Route("/api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _playerService = playerService;
        }

        private ILogger<PlayerController> _logger;

        private IPlayerService _playerService;

        [HttpGet]
        public ActionResult Get(int pageSize, int page)
        {
            PaginationParameters paginationParameters = new PaginationParameters(pageSize, page);

            paginationParameters.BaseUri = UriService.GetPlayerUri().AbsoluteUri;

            PaginatedResponse<Player> playerDataResponse = new PaginatedResponse<Player>(_playerService.GetPlayersOrdered(), paginationParameters);

            _logger.LogInformation("Successfully retrieved player information", playerDataResponse);

            return Ok(playerDataResponse);
        }
    }
}