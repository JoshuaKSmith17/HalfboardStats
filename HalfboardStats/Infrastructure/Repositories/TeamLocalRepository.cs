using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.Builders;

namespace HalfboardStats.Infrastructure.Repositories
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
                var dbTeam = context.Teams.Find(team.Id);
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
