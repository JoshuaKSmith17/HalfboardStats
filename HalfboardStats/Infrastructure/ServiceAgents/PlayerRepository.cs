using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json;
using HalfboardStats.Core.JsonMappers.PlayerMappers;
using HalfboardStats.Core.JsonMappers;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public class PlayerRepository : IPlayerRepository
    {
        public IHttpClientFactory Factory { get; set; }

        public PlayerRepository(IHttpClientFactory factory)
        {
            Factory = factory;
        }
        public async Task<List<RosterPersonMapper>> GetActivePlayers()
        {
            List<RosterPersonMapper> people = new List<RosterPersonMapper>();

            //TODO: This section up to the assigning of leagueTeamStream should get refactored to use the local team db.
            var client = Factory.CreateClient();
            client.BaseAddress = new Uri("https://statsapi.web.nhl.com/api/v1/");
            var responseTask = client.GetAsync("teams");
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();
            var league = JsonConvert.DeserializeObject<LeagueTeamsMapper>(apiResponse);

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

            leagueTeamString += "&expand=team.roster&expand=roster.person";

            responseTask = client.GetAsync(leagueTeamString);
            responseTask.Wait();
            apiResponse = await responseTask.Result.Content.ReadAsStringAsync();

            var leagueRosterMapper = JsonConvert.DeserializeObject<LeagueRosterMapper>(apiResponse);

            for (int i = 0; i < leagueRosterMapper.Teams.Count; i++)
            {
                foreach (var player in leagueRosterMapper.Teams[i].Roster.Roster)
                {

                    people.Add(player);
                }

            }

            return people;
        }

        public async Task<List<RosterPersonMapper>> GetAllPlayersAsync(string rosterYear)
        {
            //Will not need to build teams.  Removing ?Team.Id from the endpoint will automatically return only the active teams for that given year.
            //Endpoint like this will give rosters for all active teams that season.
            //https://statsapi.web.nhl.com/api/v1/teams?expand=team.roster&expand=roster.person&expand=team.roster&season=19881989
            //Iterate backwards over the years until the API returns an error code.  Should be message number 10 "object not found"
            List<RosterPersonMapper> people = new List<RosterPersonMapper>();

            var client = Factory.CreateClient();
            string address = "https://statsapi.web.nhl.com/api/v1/teams?expand=team.roster&expand=roster.person&expand=team.roster&season=" + rosterYear;

            var responseTask = client.GetAsync(address);
            responseTask.Wait();

            string apiResponse = await responseTask.Result.Content.ReadAsStringAsync();
            var leagueRosterMapper = JsonConvert.DeserializeObject<LeagueRosterMapper>(apiResponse);

                foreach (var team in leagueRosterMapper.Teams)
                {
                    if (team.Roster != null)
                    {
                        foreach (var player in team.Roster.Roster)
                        {
                            people.Add(player);
                        }
                    }
                }

            return people;




        }
    }
}
