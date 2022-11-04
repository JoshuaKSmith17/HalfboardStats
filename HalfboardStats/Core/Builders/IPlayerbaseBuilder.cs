using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.PlayerMappers;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Core.Builders
{
    public interface IPlayerbaseBuilder
    {
        public List<Player> Build(List<RosterPersonMapper> rosterPersons);

        //public Task<List<Player>> BuildAllPlayersAsync(string rosterYear);
    }
}
