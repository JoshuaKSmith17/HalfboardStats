using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class TeamRecords
    {
        public Team Team { get; set; }
        public LeagueRecord LeagueRecord { get; set; }
        public int RegulationWins { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalsScored { get; set; }
        public int Points { get; set; }
    }
}
