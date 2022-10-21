using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.ObjectRelationalMappers;
using HalfboardStats.Model.Builders;

namespace HalfboardStats.Model.LocalRepositories
{
    public class TeamLocalRepository : ITeamLocalRepository
    {
        public IServiceProvider ServiceProvider { get; set; }
        public List<Team> Teams { get; set; }
        
        public TeamLocalRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async void CreateTeams(HalfboardContext context)
        {
            var builder = (ITeamBuilder)ServiceProvider.GetService(typeof(ITeamBuilder));
            Teams = await builder.BuildTeams();

            foreach (var team in Teams)
            {
                var dbTeam = context.Teams.Find(team.TeamId);
                if (dbTeam == null)
                {
                    context.Teams.Add(team);
                }
                else
                {
                    context.Entry(dbTeam).CurrentValues.SetValues(team);
                }
            }
            context.SaveChanges();
        }
    }
}
