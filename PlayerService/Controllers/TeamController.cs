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
        [HttpGet("{name}", Name = "Get")]
        public async Task<ActionResult> Get(string name, [FromQuery] PaginationParameters paginationParameters)
        {
            var response = new PagedResponse<Player>(await PlayerRepository.GetPlayersByTeam(name), paginationParameters) ;
            
            return Ok(response);
        }
    }
}
