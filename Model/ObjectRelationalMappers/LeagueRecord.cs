using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class LeagueRecord
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ot { get; set; }
        public string LeagueType { get; set; }
    }
}
