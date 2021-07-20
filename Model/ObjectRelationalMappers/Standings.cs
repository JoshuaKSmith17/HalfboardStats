using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class Standings : IStandings
    {
        public IList<ITeamRecord> TeamRecords { get; set; }

        public Standings()
        {
            TeamRecords = new List<ITeamRecord>();
        }
    }
}
