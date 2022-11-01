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
        public IServiceProvider ServiceProvider { get; set; }

        public TeamNhlApiAgent(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task<List<TeamMapper>> GetTeams()
        {
            List<TeamMapper> teams = new List<TeamMapper>();

            var factory = (IHttpClientFactory)ServiceProvider.GetService(typeof(IHttpClientFactory));
            var client = factory.CreateClient();
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
            var league = new LeagueTeamsMapper();

            league = JsonConvert.DeserializeObject<LeagueTeamsMapper>(apiResponse);

            foreach (var team in league.Teams)
            {
                teams.Add(team);
            }

            return teams;
        }
    }
}
