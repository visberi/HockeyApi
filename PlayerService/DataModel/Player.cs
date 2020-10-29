using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerService.DataModel
{
    public class Player
    {
        #region Private Fields
        private int _playerNumber;
        #endregion


        #region Constants
        private const int MinimumPlayerNumber = 1;
        private const int MaximumPlayerNumber = 99;
        #endregion Constants


        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="playerNumber">Number of the player</param>
        /// <param name="playerPosition">Player position</param>
        /// <param name="team">Team name</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if player number is less than 1 or more than 99</exception>
        public Player(string name, int playerNumber, PlayerPosition playerPosition, string team)
        {
            Name = name;
            PlayerNumber = playerNumber;
            PlayerPosition = playerPosition;
            Team = team;
        }

  

        public string Team { get; set; }

        /// <summary>
        /// Player number of the player in the team, should be unique among players in the team.
        /// </summary>
        public int PlayerNumber
        {
            get => _playerNumber;
            set
            {
                if(value < MinimumPlayerNumber || value > MaximumPlayerNumber)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format( "Invalid player number {0}, player number must be between {1} and {2}", 
                                              value, MinimumPlayerNumber, MaximumPlayerNumber));
                }

                _playerNumber = value;
            }
        }

        public string Name { get; set; }

        /// <summary>
        /// Position of the player, used for sorting the players by position as well as for enforcing the source data format
        /// </summary>
        public PlayerPosition PlayerPosition { get; set; }

        /// <summary>
        /// Player position in string format, used for presenting the data
        /// </summary>
        public string PlayerPositionString => PlayerPosition.ToString();

        /// <summary>
        /// Custom ToString implementation used e.g. for error messages
        /// </summary>
        public override string ToString()
        {
            return Name + " player number:" + PlayerNumber;
        }
    }
}
