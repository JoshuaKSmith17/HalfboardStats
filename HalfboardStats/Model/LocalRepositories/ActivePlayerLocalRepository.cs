using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.ObjectRelationalMappers;
using HalfboardStats.Model.Builders;

namespace HalfboardStats.Model.LocalRepositories
{
    public class ActivePlayerLocalRepository : IActivePlayerLocalRepository
    {
        public IServiceProvider ServiceProvider { get; set; }
        public List<Player> Players { get; set; }

        public ActivePlayerLocalRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public async void CreateActivePlayers(HalfboardContext context)
        {

            var builder = (IPlayerbaseBuilder)ServiceProvider.GetService(typeof(IPlayerbaseBuilder));
            Players = await builder.BuildPlayers();

            //Add or update a record
            for (int i = 0; i < Players.Count; i++)
            {
                var dbPlayer = context.Players.Find(Players[i].PlayerId);
                if (dbPlayer == null)
                {
                    context.Players.Add(Players[i]);
                }
                else
                {
                    context.Entry(dbPlayer).CurrentValues.SetValues(Players[i]);
                }
            }
            context.SaveChanges();
        }
    }
}
