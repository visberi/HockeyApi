using System.Collections.Generic;
using HockeyApi.DataModel;

namespace HockeyApi.Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayersByTeam(string team);

        public IEnumerable<Player> GetPlayersOrdered();
    }
}
