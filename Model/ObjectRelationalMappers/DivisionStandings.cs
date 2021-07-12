using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class DivisionStandings
    {
        public string StandingsType { get; set; }
        public League League { get; set; }
        public Division Division { get; set; }
        public Conference Conference { get; set; }
        public List<TeamRecords> TeamRecords { get; set; }
    }
}
