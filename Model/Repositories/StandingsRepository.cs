using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json;

using HalfboardStats.Model.ObjectRelationalMappers;

namespace HalfboardStats.Model.Repositories
{
    public class StandingsRepository
    {
        Standings Standings;
        HttpClient Client;

        public StandingsRepository()
        {
            Standings = new Standings();
            Client = new HttpClient();
        }

        public async Task<Standings> GetStandings()
        {
            Client.BaseAddress = new Uri("https://statsapi.web.nhl.com/api/v1/");
            var responseTask = Client.GetAsync("standings");
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();

            Standings = JsonConvert.DeserializeObject<Standings>(apiResponse);

            return Standings;
        }
    }
}
