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
        public IPlayerRepository Repository { get; set; }

        public PlayerbaseBuilder(IPlayerRepository repository)
        {
            Repository = repository;
        }
        public async Task<List<Player>> BuildPlayers()
        {
            List<Player> players = new List<Player>();
            List<RosterPersonMapper> playerMapper = await Repository.GetActivePlayers();

            for (int i = 0; i < playerMapper.Count; i++)
            {
                var person = AdaptPlayer(playerMapper[i]);
                players.Add(person);
            }

            return players;
        }

        public async Task<List<Player>> BuildAllPlayersAsync(string rosterYear)
        {
            List<Player> players = new List<Player>();
            List<RosterPersonMapper> playerMappers = await Repository.GetAllPlayersAsync(rosterYear);

            foreach (var playerMapper in playerMappers)
            {
                var person = AdaptPlayer(playerMapper);
                players.Add(person);
            }

            return players;
        }

        private Player AdaptPlayer(RosterPersonMapper playerMapper)
        {
            var person = new Player();
            person.Id = playerMapper.Person.Id;

            string[] names = playerMapper.Person.FullName.Split(' ');
            person.FirstName = names.First();
            person.LastName = names.Last();

            if (playerMapper.Person.currentTeam != null)
            {
                person.TeamId = playerMapper.Person.currentTeam.Id;
            }

            person.PrimaryNumber = playerMapper.JerseyNumber.ToString();
            person.BirthDate = playerMapper.Person.birthDate;
            person.CurrentAge = playerMapper.Person.currentAge;
            person.BirthCity = playerMapper.Person.birthCity;
            person.BirthStateProvince = playerMapper.Person.birthStateProvince;
            person.BirthCountry = playerMapper.Person.birthCountry;
            person.Nationality = playerMapper.Person.nationality;
            person.Height = playerMapper.Person.height;
            person.Weight = playerMapper.Person.weight;
            person.IsActive = playerMapper.Person.active;
            person.IsAlternateCaptain = playerMapper.Person.alternateCaptain;
            person.IsCaptain = playerMapper.Person.captain;
            person.IsRookie = playerMapper.Person.rookie;
            person.ShootsCatches = playerMapper.Person.shootsCatches;
            person.RosterStatus = playerMapper.Person.rosterStatus;

            if (playerMapper.Position.Name == "Defensman")
            {
                person.PlayingPosition = Position.Defenseman;
            }
            else if (playerMapper.Position.Name == "Forward")
            {
                person.PlayingPosition = Position.Forward;
            }
            else if (playerMapper.Position.Name == "Center")
            {
                person.PlayingPosition = Position.Center;
            }
            else if (playerMapper.Position.Name == "Goalie")
            {
                person.PlayingPosition = Position.Goalie;
            }

            return person;
        }

    }
}
