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


            string leagueTeamString = "teams?teamId=";

            for (int i = 0; i < league.Teams.Count; i++)
            {
                if (i == league.Teams.Count - 1)
                {
                    leagueTeamString += league.Teams[i].Id;
                }
                else
                {
                    leagueTeamString += league.Teams[i].Id + ",";
                }
            }

            leagueTeamString += "&expand=team.roster";

            responseTask = client.GetAsync(leagueTeamString);
            responseTask.Wait();
            apiResponse = await responseTask.Result.Content.ReadAsStringAsync();

            var leagueRosterMapper = new LeagueRosterMapper();

            leagueRosterMapper = JsonConvert.DeserializeObject<LeagueRosterMapper>(apiResponse);

            for (int i = 0; i < leagueRosterMapper.Teams.Count; i++)
            {


                foreach (var player in leagueRosterMapper.Teams[i].Roster.Roster)
                {
                    people.Add(player);
                }

            }

            return people;
        }
    }
}
