using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class DivisionStandingsMapper
    {
        public string StandingsType { get; set; }
        public LeagueMapper League { get; set; }
        public DivisionMapper Division { get; set; }
        public ConferenceMapper Conference { get; set; }
        public List<TeamRecordsMapper> TeamRecords { get; set; }
    }
}
