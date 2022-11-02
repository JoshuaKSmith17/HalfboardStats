using HalfboardStats.Core.JsonMappers.StatsMappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public class YearByYearStatsAgent : IYearByYearStatsAgent
    {
        public IHttpClientFactory ClientFactory { get; set; }
        public YearByYearStatsAgent(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async Task<YearByYearMapper> GetCareerStats(int Id)
        {
            var client = ClientFactory.CreateClient();
            string address = "https://statsapi.web.nhl.com/api/v1/people/" + Id + "/stats?stats=yearByYear";
            var responseTask = client.GetAsync(address);
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();
            var yearByYearMapper = JsonConvert.DeserializeObject<YearByYearMapper>(apiResponse);
            return yearByYearMapper;
        }
    }
}
