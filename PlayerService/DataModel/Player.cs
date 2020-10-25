using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerService.DataModel
{
    public class Player
    {
        #region constants
        private const int MinimumPlayerNumber = 1;
        private const int MaximumPlayerNumber = 99;
        #endregion constants

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="playerNumber"></param>
        /// <param name="playerPosition"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if player number is less than 1 or more than 99</exception>
        public Player(string name, int playerNumber, PlayerPosition playerPosition)
        {

            if(playerNumber < MinimumPlayerNumber || playerNumber > MaximumPlayerNumber)
            {
                throw new ArgumentOutOfRangeException(string.Format( "Invalid player number {0}, player number must be between {1} and {2}", playerNumber, MinimumPlayerNumber, MaximumPlayerNumber));
            }
            Name = name;
            PlayerNumber = playerNumber;
            PlayerPosition = playerPosition;
        }

        public string Team { get; set; }

        /// <summary>
        /// Player number of the player in the team, should be unique among players in the team.
        /// </summary>
        public int PlayerNumber { get; set;}

  
        public string Name { get; set; }
        
        public PlayerPosition PlayerPosition { get; set; }

        /// <summary>
        /// Custom ToString implementation used e.g. for error messages
        /// </summary>
        public override string ToString()
        {
            return Name + " player number:" + PlayerNumber;
        }
    }
}
