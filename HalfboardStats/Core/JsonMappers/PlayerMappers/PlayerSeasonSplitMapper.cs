using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers.PlayerMappers
{
    public class PlayerSeasonSplitMapper
    {
        public string Season { get; set; }
        public PlayerSeasonSplitStatMapper Splits { get; set; }

    }
}
