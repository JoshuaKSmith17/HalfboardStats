using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.ObjectRelationalMappers;

namespace HalfboardStats.Model.Builders
{
    interface ITeamBuilder
    {
        public Task<List<Team>> BuildTeams();
    }
}
