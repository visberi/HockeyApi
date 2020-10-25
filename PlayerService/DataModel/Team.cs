﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerService.DataModel
{
    public class Team
    {


        /// <summary>
        /// Create a new team with optional list of players.
        /// </summary>
        /// <param name="name">Name of the team.</param>
        /// <param name="players">Optional list of players that are part of the team.</param>
        public Team(string name, List< Player>  players = null)
        {
            Name = name;
            if(players is null)
            {
                Players = new List<Player>();
            }
            foreach (var player in players)
            {
                AddPlayer(player);
            }
        }

        public string Name { get; set; }
        
        public List<Player> Players { get; }

        /// <summary>
        /// Add a new player to team
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if player with given PlayerNumber already exists in the team.</exception>
        public void AddPlayer(Player player)
        {
            if (Players.Exists(p => p.PlayerNumber == player.PlayerNumber)) // Check previous existence of player number in the team
            {
                throw new InvalidOperationException(
                    $"Error occurred when adding player {player.ToString()}: player with number {player.PlayerNumber} already exists in team {Name}");
            }

            Players.Add(player);
        }
    }
}