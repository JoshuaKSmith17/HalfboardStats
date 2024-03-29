﻿using System.Net.Http;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.StandingsMappers;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public interface IStandingsRepository
    {
        IStandingsMapper Standings { get; set; }
        IHttpClientFactory ClientFactory { get; set; }
        public Task<IStandingsMapper> GetStandings();
    }
}
