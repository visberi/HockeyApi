using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerService.DataModel
{
    /// <summary>
    /// Player positions in an ice hockey team. Abbreviations from Finnish
    /// </summary>
    public enum PlayerPosition
    {
        /// <summary>
        /// Goaltender
        /// </summary>
        Goaltender,
        /// <summary>
        /// Left defender
        /// </summary>
        LeftDefender,
        /// <summary>
        /// Right defender
        /// </summary>
        RightDefender,
        /// <summary>
        /// Left wing
        /// </summary>
        LeftWing,
        /// <summary>
        /// Center
        /// </summary>
        Center,
        /// <summary>
        /// Right wing
        /// </summary>
        RightWing
    }
}
