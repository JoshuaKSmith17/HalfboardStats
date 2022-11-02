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
        public IStandingsMapper Standings { get; set; }
        public IHttpClientFactory ClientFactory { get; set; }

        public StandingsRepository(IStandingsMapper standings, IHttpClientFactory clientFactory)
        {
            Standings = standings;
            ClientFactory = clientFactory;
        }

        public async Task<IStandingsMapper> GetStandings()
        {
            var client = ClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://statsapi.web.nhl.com/api/v1/");
            var responseTask = client.GetAsync("standings");
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();

            Standings = JsonConvert.DeserializeObject<StandingsMapper>(apiResponse);

            return Standings;
        }
    }
}
