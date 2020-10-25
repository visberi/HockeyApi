using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using PlayerService.DataModel;

namespace PlayerService.Controllers
{
    /// <summary>
    /// Player data provider that reads player data from a json file, caches it and provides interface to read it.
    /// </summary>
    public static class PlayerDataProvider
    {


        private const string DataFilePath =  "./PlayerData.csv";

        // Cache players read from data source into this variable
        private static IEnumerable<Player> _players = null;

        public static IEnumerable<Player> Players
        {
            // Return cached players or if no cache exists, read data from CSV file
            get { return _players ??= InitializePlayerDataFromCsv(); }
        }

        /// <summary>
        /// Reads player data from resource csv file into cache and parses it into object form
        /// </summary>
  
        private static IEnumerable<Player> InitializePlayerDataFromCsv()
        {

            string playerTextData = Properties.Resources.PlayerData;
            using TextReader reader = new StringReader(playerTextData);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            
  
            List<Player> players = new List<Player>();
            csvReader.Read();
            csvReader.ReadHeader();
            while (csvReader.Read())
            {
                int playerNumber = csvReader.GetField<int>("PlayerNumber");
                string playerName = csvReader.GetField<string>("Name");
                string team = csvReader.GetField<string>("Team");
                string position = csvReader.GetField<string>("PlayerPosition");
                if (!Enum.IsDefined(typeof(PlayerPosition), position))
                {
                    throw new InvalidDataException(
                        String.Format("Invalid player position type {0}, use one of following: G, LD, RD, LW, RW, C",
                            position));
                }

                players.Add(new Player(playerName, playerNumber, Enum.Parse<PlayerPosition>(position), team));

            }

            ValidatePlayerData(players);

            return players;

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
                foreach (var group in data)
                {
                    errorBuilder.Append(String.Format("Team: {0}, Number: {1}", group.Team, group.PlayerNumber) + Environment.NewLine);
                }
                throw new InvalidOperationException(errorBuilder.ToString());
            }
        }
    }

 
}
