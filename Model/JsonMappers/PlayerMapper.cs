using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class PlayerMapper
    {
        public PersonMapper Person { get; set; }
        public int JerseyNumber { get; set; }
        public PositionMapper Position { get; set; }
    }
}
