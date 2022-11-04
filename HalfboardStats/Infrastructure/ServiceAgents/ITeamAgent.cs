using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.StandingsMappers;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public interface ITeamAgent
    {
        public Task<List<TeamMapper>> GetTeams();
    }
}
