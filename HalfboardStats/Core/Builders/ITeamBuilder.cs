using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.ServiceAgents;

namespace HalfboardStats.Core.Builders
{
    public interface ITeamBuilder
    {
        public ITeamAgent ServiceAgent { get; set; }
        public Task<List<Team>> BuildTeams();
    }
}
