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
        G,
        /// <summary>
        /// Left defender
        /// </summary>
        LD,
        /// <summary>
        /// Right defender
        /// </summary>
        RD,
        /// <summary>
        /// Left wing
        /// </summary>
        LW,
        /// <summary>
        /// C
        /// </summary>
        C,
        /// <summary>
        /// Right wing
        /// </summary>
        RW
    }
}
