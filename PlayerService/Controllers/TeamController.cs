using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayerService.Contracts;
using PlayerService.DataModel;

namespace PlayerService.Controllers
{
    [Route("/api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {


        // GET: api/Team/Team Name
        [HttpGet("{name}", Name = "Get")]
        public  object Get(string name, [FromQuery] PaginationParameters paginationParameters)
        {
            return new PagedResponse<Player>(PlayerDataProvider.GetPlayersByTeam(name), paginationParameters) ;
        }

    }
}
