using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using HalfboardStats.Core.JsonMappers.StandingsMappers;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public class StandingsRepository : IStandingsRepository
    {
        IStandingsMapper Standings;
        IServiceProvider ServiceProvider { get; }

        public StandingsRepository(IServiceProvider serviceProvider)
        {
            Standings = (IStandingsMapper)serviceProvider.GetService(typeof(IStandingsMapper));
            ServiceProvider = serviceProvider;

        }

        public async Task<IStandingsMapper> GetStandings()
        {
            var factory = (IHttpClientFactory)ServiceProvider.GetService(typeof(IHttpClientFactory));

            var client = factory.CreateClient();

            client.BaseAddress = new Uri("https://statsapi.web.nhl.com/api/v1/");
            var responseTask = client.GetAsync("standings");
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();

            Standings = JsonConvert.DeserializeObject<StandingsMapper>(apiResponse);

            return Standings;
        }
    }
}
