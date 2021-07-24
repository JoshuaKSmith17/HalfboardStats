using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class LeagueTeamsMapper
    {
        public string Copyright { get; set; }
        public List<TeamMapper> Teams { get; set; }

    }
}
