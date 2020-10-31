﻿using System;
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
    ///
    /// While the data is cached in memory, asynchronous operation of the interface is not strictly necessary.
    /// However, it was made async for learning purposes.
    /// </summary>
    public static class PlayerRepository
    {
        // Cache players read from data source into this variable
        private static List<Player> _players = null;


        private static async Task<List<Player>> GetPlayersAsync()
        {
            // Return cached players or if no cache exists, read data from CSV file
            if (_players == null)
            {
                _players = await InitializePlayerDataFromCsv();
            }
            return _players;
        }

        /// <summary>
        /// Get players ordered by team and player number in ascending order
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<Player>> GetPlayersByTeam(string team)
        {
            var players = await GetPlayersAsync();

            return players
                .Where(p => p.Team == team)
                .OrderBy(p => p.PlayerNumber);
        }

        /// <summary>
        /// Return the players as written in specification:
        /// Ordered by Team, player position and player number in ascending order
        /// </summary>
        /// <returns>The players ordered and paginated as dictated by paginationParameters</returns>
        public static async Task<IEnumerable<Player>> GetPlayersOrdered()
        {
            var players = await GetPlayersAsync();

            return players
                .OrderBy(p => p.Team)
                .ThenBy(p => p.PlayerPosition)
                .ThenBy(p => p.PlayerNumber);
        }

        /// <summary>
        /// Reads player data from resource csv file into cache, validates it and parses it into object form
        /// </summary>
  
        private static async Task<List<Player>> InitializePlayerDataFromCsv()
        {

            string playerTextData = Properties.Resources.PlayerData;

            using TextReader reader = new StringReader(playerTextData);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            List<Player> players = new List<Player>();

            await csvReader.ReadAsync();

            csvReader.ReadHeader();

            while (await csvReader.ReadAsync())
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

                foreach (var group in invalidData)
                {
                    errorBuilder.Append(String.Format("Team: {0}, Number: {1}", group.First().Team, group.First().PlayerNumber) + Environment.NewLine);
                }
                throw new InvalidOperationException(errorBuilder.ToString());
            }
        }
    }
}