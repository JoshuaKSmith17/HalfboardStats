using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class TeamRosterMapper
    {
        public string Copyright { get; set; }
        public List<RosterPersonMapper> Roster { get; set; }
    }
}
