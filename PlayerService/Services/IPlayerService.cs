using System.Collections.Generic;
using PlayerService.DataModel;

namespace PlayerService.Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayersByTeam(string team);

        public IEnumerable<Player> GetPlayersOrdered();
    }
}
