using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using HalfboardStats.Core.JsonMappers.StandingsMappers;
using HalfboardStats.Core.JsonMappers;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public class TeamNhlApiAgent : ITeamAgent
    {
        public IHttpClientFactory Factory { get; set; }

        public TeamNhlApiAgent(IHttpClientFactory factory)
        {
            Factory = factory;
        }

        public async Task<List<TeamMapper>> GetTeamsAsync()
        {
            List<TeamMapper> teams = new List<TeamMapper>();
            
            var client = Factory.CreateClient();
            string address = "https://statsapi.web.nhl.com/api/v1/teams/?teamId=";

            for(int i = 1; i <= 1000; i++)
            {
                address += i;
                if (i < 1000)
                {
                    address += ",";
                }
            }

            var responseTask = client.GetAsync(address);
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();
            var league = JsonConvert.DeserializeObject<LeagueTeamsMapper>(apiResponse);

            foreach (var team in league.Teams)
            {
                teams.Add(team);
            }

            return teams;
        }
    }
}
