using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers.PlayerMappers
{
    public class RosterPersonMapper
    {
        /* This mapper might at first appear confusing.  Why have this abbreviated mapper for a roster player
         * when we have another full mapper for a player.  This is due to how the NHL API structures their 
         * data.  When a person is pulled via the team's roster, it displays a different data set than when
         * a person's data is requested via the /people endpoint.  This class is used as a stepping stone
         * to obtain the full data set of the player from the API.
         */
        public PersonMapper Person { get; set; }
        public int JerseyNumber { get; set; }
        public PositionMapper Position { get; set; }


    }
}
