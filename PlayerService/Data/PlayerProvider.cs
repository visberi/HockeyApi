using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using PlayerService.Data;
using PlayerService.DataModel;
using PlayerService.Properties;

namespace PlayerService.Controllers
{
    /// <summary>
    /// Player data provider layer
    /// </summary>
    public static class PlayerProvider
    {
        /// <summary>
        /// Get players ordered by team and player number in ascending order
        /// </summary>
        public static IEnumerable<Player> GetPlayersByTeam(string team)
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
        public static IEnumerable<Player> GetPlayersOrdered()
        {
            var players = PlayerRepository.GetPlayers();

            return players
                .OrderBy(p => p.Team)
                .ThenBy(p => p.PlayerPosition)
                .ThenBy(p => p.PlayerNumber);
        }
    }
}
