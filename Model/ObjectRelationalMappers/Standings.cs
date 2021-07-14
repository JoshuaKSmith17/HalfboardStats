using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class Standings
    {
        public string Copyright { get; set; }
        public List<DivisionStandings> Records { get; set; }
    }
}
