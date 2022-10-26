using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers.StandingsMappers
{
    public interface IStandingsMapper
    {
        public string Copyright { get; set; }
        public List<DivisionStandingsMapper> Records { get; set; }
    }
}
