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
        public ITeamBuilder Builder { get; set; }
        public HalfboardContext Context { get; set; }
        public List<Team> Teams { get; set; }

        public TeamLocalRepository(ITeamBuilder builder, HalfboardContext context)
        {
            Builder = builder;
            Context = context;
        }

        public async void CreateTeams()
        {
            Teams = await Builder.BuildTeams();

            foreach (var team in Teams)
            {
                var dbTeam = Context.Teams.Find(team.Id);
                if (dbTeam == null)
                {
                    Context.Teams.Add(team);
                }
                else
                {
                    Context.Entry(dbTeam).CurrentValues.SetValues(team);
                }
            }
            Context.SaveChanges();
        }
    }
}
