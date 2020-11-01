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
using PlayerService.Services;

namespace PlayerService.Controllers
{
    [Route("/api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(int pageSize, int page)
        {
            PaginationParameters paginationParameters = new PaginationParameters(pageSize, page);
            paginationParameters.BaseUri = UriService.GetPlayerUri();
            PaginatedResponse<Player> playerDataResponse = new PaginatedResponse<Player>(PlayerProvider.GetPlayersOrdered(), paginationParameters);

            return Ok(playerDataResponse);
        }
    }
}