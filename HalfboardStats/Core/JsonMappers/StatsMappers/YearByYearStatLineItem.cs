using HalfboardStats.Core.JsonMappers.PlayerMappers;
using HalfboardStats.Core.JsonMappers.StandingsMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers.StatsMappers
{
    public class YearByYearStatLineItem
    {
        public string Season { get; set; }
        public PlayerSeasonSplitStatMapper Stat { get; set; }
        public TeamMapper Team { get; set; }
        public LeagueMapper League { get; set; }
    }
}
