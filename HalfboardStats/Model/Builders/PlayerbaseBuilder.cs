using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.JsonMappers;
using HalfboardStats.Model.ObjectRelationalMappers;
using HalfboardStats.Model.Repositories;

namespace HalfboardStats.Model.Builders
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

                players.Add(person);

            }

            return players;
            
        }

    }
}
