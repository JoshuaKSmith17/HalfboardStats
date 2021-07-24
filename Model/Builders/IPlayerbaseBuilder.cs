using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.ObjectRelationalMappers;

namespace HalfboardStats.Model.Builders
{
    interface IPlayerbaseBuilder
    {
        public Task<List<Player>> BuildPlayers();
    }
}
