using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class StandingsMapper : IStandingsMapper
    {
        public string Copyright { get; set; }
        public List<DivisionStandingsMapper> Records { get; set; }
    }
}
