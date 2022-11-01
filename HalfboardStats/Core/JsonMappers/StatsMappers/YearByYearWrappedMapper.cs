using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers.StatsMappers
{
    public class YearByYearWrappedMapper
    {
        public SeasonTypeMapper Type { get; set; }
        public List<YearByYearStatLineItem> Splits { get; set; }

    }
}
