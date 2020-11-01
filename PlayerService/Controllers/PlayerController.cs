using System;
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
        [HttpGet]
        public ActionResult Get([FromQuery] PaginationParameters paginationParameters)
        {
            PaginatedResponse<Player> playerDataResponse = new PaginatedResponse<Player>(  PlayerProvider.GetPlayersOrdered(), paginationParameters);
            
            return Ok(playerDataResponse);
        }
    }
}