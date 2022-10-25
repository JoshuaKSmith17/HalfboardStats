using HalfboardStats.Core.JsonMappers.PlayerMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers
{
    public class TeamRosterMapper
    {
        public string Copyright { get; set; }
        public List<RosterPersonMapper> Roster { get; set; }
    }
}
