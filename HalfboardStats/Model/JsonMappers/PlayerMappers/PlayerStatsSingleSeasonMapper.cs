using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class PlayerStatsSingleSeasonMapper
    {
        public string Copyright { get; set; }
        public SeasonTypeMapper Type { get; set; }
        public PlayerSeasonSplitMapper Splits { get; set; }

    }
}
