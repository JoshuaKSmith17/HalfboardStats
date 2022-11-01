using HalfboardStats.Core.JsonMappers.PlayerMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers.StatsMappers
{
    public class YearByYearMapper
    {
        public string Copyright { get; set; }
        public List<YearByYearWrappedMapper> Stats { get; set; }
    }
}
