using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using HalfboardStats.Model.JsonMappers;

namespace HalfboardStats.Model.Repositories
{
    public class StandingsRepository
    {
        StandingsMapper Standings;
        IServiceProvider ServiceProvider { get; }

        public StandingsRepository(IServiceProvider serviceProvider)
        {
            Standings = new StandingsMapper();
            ServiceProvider = serviceProvider;
            
        }

        public async Task<StandingsMapper> GetStandings()
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
