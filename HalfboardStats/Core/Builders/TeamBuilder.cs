using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.StandingsMappers;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.ServiceAgents;

namespace HalfboardStats.Core.Builders
{
    public class TeamBuilder : ITeamBuilder
    {
        public TeamBuilder()
        { 
        }

        public List<Team> BuildTeams(List<TeamMapper> teamMapper)
        {
            List<Team> teams = new List<Team>();

            foreach (var t in teamMapper)
            {
                var team = new Team();

                team.Id = t.Id;
                team.DivisionId = t.Division.Id;
                team.FranchiseId = t.FranchiseId;
                team.Name = t.Name;
                team.Link = t.Link;
                team.Abbreviation = t.Abbreviation;
                team.TeamName = t.TeamName;
                team.LocationName = t.LocationName;
                team.FirstYearOfPlay = t.FirstYearOfPlay;
                team.ShortName = t.ShortName;
                team.OfficialSiteUrl = t.OfficialSiteUrl;
                team.IsActive = t.Active;

                teams.Add(team);

            }
            return teams;
        }
    }
}
