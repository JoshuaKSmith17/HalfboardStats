using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers
{
    public class LeagueRosterMapper
    {
        public string Copyright { get; set; }
        public List<RosterMapper> Teams { get; set; }
    }
}
