using System.Collections.Generic;
using System.Linq;
using HockeyApi.Data;
using HockeyApi.DataModel;

namespace HockeyApi.Services
{
    /// <summary>
    /// Player data provider layer
    /// </summary>
    public class PlayerService: IPlayerService
    {
        /// <summary>
        /// Get players ordered by team and player number in ascending order
        /// </summary>
        public IEnumerable<Player> GetPlayersByTeam(string team)
        {
            var players = PlayerRepository.GetPlayers();

            return players
                .Where(p => p.Team == team)
                .OrderBy(p => p.PlayerNumber);
        }

        /// <summary>
        /// Return the players as written in specification:
        /// Ordered by Team, player position and player number in ascending order
        /// </summary>
        /// <returns>The players ordered and paginated as dictated by paginationParameters</returns>
        public IEnumerable<Player> GetPlayersOrdered()
        {
            var players = PlayerRepository.GetPlayers();

            return players
                .OrderBy(p => p.Team)
                .ThenBy(p => p.PlayerPosition)
                .ThenBy(p => p.PlayerNumber);
        }
    }
}
