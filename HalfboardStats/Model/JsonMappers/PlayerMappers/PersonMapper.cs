using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class PersonMapper
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Link { get; set; }
        public string birthDate { get; set; }
        public int currentAge { get; set; }
        public string birthCity { get; set; }
        public string birthStateProvince { get; set; }
        public string birthCountry { get; set; }
        public string nationality { get; set; }
        public string height { get; set; }
        public int weight { get; set; }
        public bool active { get; set; }
        public bool alternateCaptain { get; set; }
        public bool captain { get; set; }
        public bool rookie { get; set; }
        public string shootsCatches { get; set; }
        public string rosterStatus { get; set; }

        public TeamMapper currentTeam { get; set; }
    }
}
