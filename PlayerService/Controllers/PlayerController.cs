﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayerService.Contracts;
using PlayerService.DataModel;

namespace PlayerService.Controllers
{
    [Route("/api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult Get([FromQuery] PaginationParameters paginationParameters)
        {
            var playerDataResponse = new PagedResponse<Player>(  PlayerProvider.GetPlayersOrdered(), paginationParameters);
            
            return Ok(playerDataResponse);
        }
    }
}