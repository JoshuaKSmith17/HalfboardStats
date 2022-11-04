using HalfboardStats.Core.JsonMappers.PlayerMappers;
using HalfboardStats.Core.JsonMappers.StatsMappers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public class StatsNhlApiAgent : IStatsAgent
    {
        public IHttpClientFactory ClientFactory { get; set; }
        public StatsNhlApiAgent(IHttpClientFactory clientFactory)
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

        public async Task<YearByYearMapper> GetSeasonStats(int Id)
        {
            var client = ClientFactory.CreateClient();
            string address = "https://statsapi.web.nhl.com/api/v1/people/" + Id + "/stats?stats=statsSingleSeason";
            var responseTask = client.GetAsync(address);
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();
            var yearByYearMapper = JsonConvert.DeserializeObject<YearByYearMapper>(apiResponse);

            if (yearByYearMapper.Stats[0].Splits.Count != 0)
            {
                // Single Season GET request doesn't give the player's team.  Use separate request to obtain team ID.
                address = "https://statsapi.web.nhl.com/api/v1/people/" + Id;
                responseTask = client.GetAsync(address);
                responseTask.Wait();
                apiResponse = await responseTask.Result.Content.ReadAsStringAsync();
                var personMapper = JsonConvert.DeserializeObject<PersonMapperById>(apiResponse);

                yearByYearMapper.Stats[0].Splits[0].Team = personMapper.People[0].currentTeam;
            }


            return yearByYearMapper;
        }
    }
}
