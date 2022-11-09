using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.PlayerMappers;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;

namespace HalfboardStats.Core.Builders
{
    public interface IPlayerbaseBuilder
    {
        public List<IPlayer> Build(List<RosterPersonMapper> rosterPersons);

        //public Task<List<Player>> BuildAllPlayersAsync(string rosterYear);
    }
}
