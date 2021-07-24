using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class TeamRecordsMapper
    {
        public TeamMapper Team { get; set; }
        public LeagueRecordMapper LeagueRecord { get; set; }
        public int RegulationWins { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalsScored { get; set; }
        public int Points { get; set; }
    }
}
