using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json;

using HalfboardStats.Model.JsonMappers;

namespace HalfboardStats.Model.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public IServiceProvider ServiceProvider { get; set; }

        public PlayerRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public async Task<List<RosterPersonMapper>> GetActivePlayers()
        {
            List<RosterPersonMapper> people = new List<RosterPersonMapper>();

            var factory = (IHttpClientFactory)ServiceProvider.GetService(typeof(IHttpClientFactory));
            var client = factory.CreateClient();
            client.BaseAddress = new Uri("https://statsapi.web.nhl.com/api/v1/");
            var responseTask = client.GetAsync("teams");
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();
            var league = new LeagueTeamsMapper();

            league = JsonConvert.DeserializeObject<LeagueTeamsMapper>(apiResponse);

            for (int i = 0; i < league.Teams.Count; i++)
            {
                responseTask = client.GetAsync("teams/" + league.Teams[i].Id + "/roster");
                responseTask.Wait();
                string apiRosterResponse = await responseTask.Result.Content.ReadAsStringAsync();
                var teamRoster = new TeamRosterMapper();
                teamRoster = JsonConvert.DeserializeObject<TeamRosterMapper>(apiRosterResponse);

                for (int j = 0; j < teamRoster.Roster.Count; j++)
                {
                    people.Add(teamRoster.Roster[j]);
                }

            }

            return people;
        }
    }
}
