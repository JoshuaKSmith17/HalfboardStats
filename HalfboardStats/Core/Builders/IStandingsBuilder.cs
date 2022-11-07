using HalfboardStats.Core.JsonMappers.StandingsMappers;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using HalfboardStats.Infrastructure.ServiceAgents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Builders
{
    public interface IStandingsBuilder
    {
        IStandingsAgent Repository { get; set; }
        IStandings Standings { get; set; }
        IStandingsMapper StandingsMapper { get; set; }

        Task<IDictionary<string, IEnumerable<ITeamRecord>>> BuildStandings();
    }
}