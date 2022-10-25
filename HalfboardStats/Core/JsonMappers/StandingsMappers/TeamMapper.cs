using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers.StandingsMappers
{
    public class TeamMapper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public VenueMapper Venue { get; set; }
        public string Abbreviation { get; set; }
        public string TeamName { get; set; }
        public string LocationName { get; set; }
        public int FirstYearOfPlay { get; set; }
        public DivisionMapper Division { get; set; }
        public ConferenceMapper Conference { get; set; }
        public FranchiseMapper Franchise { get; set; }
        public string ShortName { get; set; }
        public string OfficialSiteUrl { get; set; }
        public int FranchiseId { get; set; }
        public bool Active { get; set; }


    }
}
