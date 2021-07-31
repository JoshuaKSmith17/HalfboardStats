using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalfboardStats.Model.Repositories;
using HalfboardStats.Model.JsonMappers;

namespace HalfboardStats.Tests.Mockups
{
    class StandingsRepositoryMockup : IStandingsRepository
    {
        IServiceProvider ServiceProvider;
        IStandingsMapper Standings;
        public StandingsRepositoryMockup(IServiceProvider serviceProvider, IStandingsMapper standings)
        {
            ServiceProvider = serviceProvider;
            Standings = (IStandingsMapper)ServiceProvider.GetService(typeof(IStandingsMapper));
        }
        public Task<IStandingsMapper> GetStandings()
        {
            return Task.FromResult(Standings);
        }
    }
}
