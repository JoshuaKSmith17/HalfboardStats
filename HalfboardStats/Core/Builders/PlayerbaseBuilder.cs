using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.PlayerMappers;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.ServiceAgents;

namespace HalfboardStats.Core.Builders
{
    public class PlayerbaseBuilder : IPlayerbaseBuilder
    {
        public IServiceProvider ServiceProvider { get; set; }

        public PlayerbaseBuilder(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public async Task<List<Player>> BuildPlayers()
        {
            var repo = (IPlayerRepository)ServiceProvider.GetService(typeof(IPlayerRepository));
            List<Player> players = new List<Player>();

            List<RosterPersonMapper> playerMapper = await repo.GetActivePlayers();

            for (int i = 0; i < playerMapper.Count; i++)
            {
                var person = new Player();
                person.PlayerId = playerMapper[i].Person.Id;

                string[] names = playerMapper[i].Person.FullName.Split(' ');
                person.FirstName = names.First();
                person.LastName = names.Last();

                person.TeamId = playerMapper[i].Person.currentTeam.Id;
                person.PrimaryNumber = playerMapper[i].JerseyNumber.ToString();
                person.BirthDate = playerMapper[i].Person.birthDate;
                person.CurrentAge = playerMapper[i].Person.currentAge;
                person.BirthCity = playerMapper[i].Person.birthCity;
                person.BirthStateProvince = playerMapper[i].Person.birthStateProvince;
                person.BirthCountry = playerMapper[i].Person.birthCountry;
                person.Nationality = playerMapper[i].Person.nationality;
                person.Height = playerMapper[i].Person.height;
                person.Weight = playerMapper[i].Person.weight;
                person.IsActive = playerMapper[i].Person.active;
                person.IsAlternateCaptain = playerMapper[i].Person.alternateCaptain;
                person.IsCaptain = playerMapper[i].Person.captain;
                person.IsRookie = playerMapper[i].Person.rookie;
                person.ShootsCatches = playerMapper[i].Person.shootsCatches;
                person.RosterStatus = playerMapper[i].Person.rosterStatus;

                if (playerMapper[i].Position.Name == "Defensman")
                {
                    person.PlayingPosition = Position.Defenseman;
                }
                else if (playerMapper[i].Position.Name == "Forward")
                {
                    person.PlayingPosition = Position.Forward;
                }
                else if (playerMapper[i].Position.Name == "Center")
                {
                    person.PlayingPosition = Position.Center;
                }
                else if (playerMapper[i].Position.Name == "Goalie")
                {
                    person.PlayingPosition = Position.Goalie;
                }

                players.Add(person);

            }

            return players;

        }

    }
}
