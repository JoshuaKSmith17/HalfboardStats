using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Infrastructure.Repositories
{
    interface IActivePlayerLocalRepository
    {
        public void CreateActivePlayers(HalfboardContext context);
        public List<Player> GetActivePlayers(HalfboardContext context);
        public void CreateAllPlayersAsync(HalfboardContext context);
    }
}
