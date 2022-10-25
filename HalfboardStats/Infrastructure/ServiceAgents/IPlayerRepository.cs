using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.PlayerMappers;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    interface IPlayerRepository
    {
        public Task<List<RosterPersonMapper>> GetActivePlayers();
    }
}
