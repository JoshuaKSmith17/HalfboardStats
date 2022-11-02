using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.Builders;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Infrastructure.Repositories
{
    public interface IActivePlayerLocalRepository
    {
        public IPlayerbaseBuilder Builder { get; set; }
        public HalfboardContext Context { get; set; }
        public void CreateActivePlayers();
        public List<Player> GetActivePlayers();
        public void CreateAllPlayersAsync();
        public List<Player> GetPlayers();
    }
}
