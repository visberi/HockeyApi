using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerService.DataModel;

namespace PlayerService.Data
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayersByTeam(string team);

        public IEnumerable<Player> GetPlayersOrdered();
    }
}
