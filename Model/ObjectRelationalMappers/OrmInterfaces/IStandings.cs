using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public interface IStandings
    {
        public List<TeamRecord> TeamRecords { get; set; }
    }
}
