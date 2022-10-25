using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers
{
    public class TimeZoneMapper
    {
        public string Id { get; set; }
        public int Offset { get; set; }
        public string Tz { get; set; }
    }
}
