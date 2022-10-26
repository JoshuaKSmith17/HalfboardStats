using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers
{
    public class VenueMapper
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public string City { get; set; }
        public TimeZoneMapper TimeZone { get; set; }
    }
}
