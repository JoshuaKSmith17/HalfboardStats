using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers
{
    public class GameTypeMapper
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool Postseason { get; set; }

    }
}
