using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces
{
    public interface IStandings
    {
        public IList<ITeamRecord> TeamRecords { get; set; }
    }
}
