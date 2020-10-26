using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayerService.DataModel;

namespace PlayerService.Controllers
{
    [Route("/players/")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet]
        public object Get(int page)
        {

            var playerData = PlayerDataProvider.GetPlayers();

            return Ok(playerData);
        }

    }
}