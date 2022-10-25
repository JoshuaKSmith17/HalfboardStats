using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Core.Builders
{
    interface IPlayerbaseBuilder
    {
        public Task<List<Player>> BuildPlayers();
    }
}
