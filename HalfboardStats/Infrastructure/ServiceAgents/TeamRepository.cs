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
    public class TeamRepository : ITeamRepository
    {
        public IServiceProvider ServiceProvider { get; set; }

        public TeamRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task<List<TeamMapper>> GetTeams()
        {
            List<TeamMapper> teams = new List<TeamMapper>();

            var factory = (IHttpClientFactory)ServiceProvider.GetService(typeof(IHttpClientFactory));
            var client = factory.CreateClient();
            client.BaseAddress = new Uri("https://statsapi.web.nhl.com/api/v1/");
            var responseTask = client.GetAsync("teams");
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
