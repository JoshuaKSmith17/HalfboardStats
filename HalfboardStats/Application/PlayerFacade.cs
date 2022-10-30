using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public class PlayerFacade : FacadeBase, IPlayerFacade
    {

        public PlayerFacade(IServiceProvider serviceProvider, HalfboardContext context) : base(serviceProvider, context)
        {
        }


        public List<Player> GetActivePlayers()
        {
            var repo = (IActivePlayerLocalRepository)ServiceProvider.GetService(typeof(IActivePlayerLocalRepository));
            var players = repo.GetActivePlayers(Context);

            return players;
        }
    }
}
