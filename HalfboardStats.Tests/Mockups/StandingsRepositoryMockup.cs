using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.StandingsMappers;
using HalfboardStats.Infrastructure.ServiceAgents;

namespace HalfboardStats.Tests.Mockups
{
    class StandingsRepositoryMockup : IStandingsAgent
    {
        public IStandingsMapper Standings { get; set; }
        public IHttpClientFactory ClientFactory { get; set; }
        public StandingsRepositoryMockup(IStandingsMapper standings)
        {
            Standings = standings;
        }
        public Task<IStandingsMapper> GetStandings()
        {
            return Task.FromResult(Standings);
        }
    }
}
