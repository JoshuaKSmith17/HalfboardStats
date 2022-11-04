using HalfboardStats.Core.Controllers;
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
        public IPlayerController Controller{ get; set; }
        public PlayerFacade(IPlayerController controller)
        {
            Controller = controller;
        }

        public async Task<List<Player>> GetActivePlayers()
        {
            var players = await Controller.GetActivePlayers();
            return players;
        }
    }
}
