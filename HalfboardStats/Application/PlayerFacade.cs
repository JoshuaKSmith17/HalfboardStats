using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public class PlayerFacade : IPlayerFacade
    {
        public IActivePlayerLocalRepository Repository { get; set; }
        public PlayerFacade(IActivePlayerLocalRepository repository)
        {
            Repository = repository;
        }

        public List<Player> GetActivePlayers()
        {
            var players = Repository.GetActivePlayers();
            return players;
        }
    }
}
