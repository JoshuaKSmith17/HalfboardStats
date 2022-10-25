using HalfboardStats.Core.JsonMappers.StandingsMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers
{
    public class LeagueTeamsMapper
    {
        public string Copyright { get; set; }
        public List<TeamMapper> Teams { get; set; }

    }
}
