using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.ObjectRelationalMappers
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
