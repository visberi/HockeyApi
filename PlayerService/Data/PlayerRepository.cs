using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using PlayerService.DataModel;
using PlayerService.Properties;

namespace PlayerService.Data
{
    public static class PlayerRepository
    {
        // Cache players read from data source into this variable
        private static List<Player> _players = null;

        /// <summary>
        /// Get list of players loaded in memory. If no loading has been done, load default player list from resource
        /// files
        /// </summary>
        /// <returns></returns>
        public static List<Player> GetPlayers()
        {
            if (_players is null)
            {
                throw new InvalidOperationException("Error: player data has not been initialized.");
            }
            // Return cached players or if no cache exists, read data from CSV file
            return _players;
        }

        /// <summary>
        /// Reads player data from resource csv file into cache, validates it and parses it into object form
        ///
        /// This is called at Startup.cs with default data but can be invoked later to change data. Not beautiful but
        /// good enough for the purpose.
        /// </summary>
        public static void InitializePlayerDataFromCsv(string csvPlayerData)
        {

            using TextReader reader = new StringReader(csvPlayerData);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            List<Player> players = new List<Player>();

            csvReader.Read();

            csvReader.ReadHeader();

            while ( csvReader.Read())
            {
                int playerNumber = csvReader.GetField<int>("PlayerNumber");

                // Trim the string fields to make the data reading more robust.
                string playerName = csvReader.GetField<string>("Name").Trim();

                string team = csvReader.GetField<string>("Team").Trim();

                // Get position first as string instead of enum member to trim whitespaces
                string positionString = csvReader.GetField<string>("PlayerPosition").Trim(); 

                // Check if the given string data is valid PlayerPosition
                if (!Enum.IsDefined(typeof(PlayerPosition), positionString))
                {
                    throw new InvalidDataException(
                        String.Format("Invalid player position type {0}, use one of following: G, LD, RD, LW, RW, C",
                            positionString));
                }

                players.Add(new Player(playerName, playerNumber, Enum.Parse<PlayerPosition>(positionString), team));
            }

            ValidatePlayerData(players);

            _players = players;
        }

        /// <summary>
        /// Validate the player data: no team shall have duplicate player number
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws invalid exception if multiple players are tried to add with same number in team.</exception>
        private static void ValidatePlayerData(IEnumerable<Player> data)
        {
            bool arePlayerNumbersInTeamDistinct = data.GroupBy(p => new{p.Team, p.PlayerNumber}).All(x => x.Count() == 1);

            if (!arePlayerNumbersInTeamDistinct)
            {
                var invalidData =
                    data.GroupBy(p => new {p.Team, p.PlayerNumber}).Where(x => x.Count() > 1);

                StringBuilder errorBuilder = new StringBuilder();

                errorBuilder.Append("Error when reading player data: Following player number/ team pairs have multiple entries in data: " + Environment.NewLine);

                foreach (var group in invalidData)
                {
                    errorBuilder.Append(String.Format("Team: {0}, Number: {1}", group.First().Team, group.First().PlayerNumber) + Environment.NewLine);
                }
                throw new InvalidOperationException(errorBuilder.ToString());
            }
        }
    }
}
