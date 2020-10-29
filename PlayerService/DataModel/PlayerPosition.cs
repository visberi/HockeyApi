using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerService.DataModel
{
    /// <summary>
    /// Player positions in an ice hockey team, used for making input validity check when reading from CSV.
    /// </summary>
    public enum PlayerPosition
    {
        /// <summary>
        /// Center
        /// </summary>
        C,
        /// <summary>
        /// Right wing
        /// </summary>
        RW,
        /// <summary>
        /// Left wing
        /// </summary>
        LW,
        /// <summary>
        /// Left defender
        /// </summary>
        LD,
        /// <summary>
        /// Right defender
        /// </summary>
        RD,
        /// <summary>
        /// Goaltender
        /// </summary>
        G
    }
}
