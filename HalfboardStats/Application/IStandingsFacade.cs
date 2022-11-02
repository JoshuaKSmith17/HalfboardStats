using HalfboardStats.Core.Builders;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public interface IStandingsFacade
    {
        IStandingsBuilder StandingsBuilder { get; set; }

        Task<IDictionary<string, IEnumerable<ITeamRecord>>> GetStandings();
    }
}