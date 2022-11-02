using HalfboardStats.Core.Builders;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public class StandingsFacade : IStandingsFacade
    {
        public IStandingsBuilder StandingsBuilder { get; set; }
        public StandingsFacade(IStandingsBuilder builder)
        {
            StandingsBuilder = builder;
        }
        public async Task<IDictionary<string, IEnumerable<ITeamRecord>>> GetStandings()
        {
            var standings = await StandingsBuilder.BuildStandings();
            return standings;
        }
    }
}
