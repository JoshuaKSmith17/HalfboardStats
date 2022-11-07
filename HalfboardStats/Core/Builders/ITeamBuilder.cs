using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.StandingsMappers;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.ServiceAgents;

namespace HalfboardStats.Core.Builders
{
    public interface ITeamBuilder
    {
        public List<Team> BuildTeams(List<TeamMapper> teamMapper);
    }
}
