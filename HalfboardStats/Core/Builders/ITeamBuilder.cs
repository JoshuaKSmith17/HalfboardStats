using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Core.Builders
{
    interface ITeamBuilder
    {
        public Task<List<Team>> BuildTeams();
    }
}
