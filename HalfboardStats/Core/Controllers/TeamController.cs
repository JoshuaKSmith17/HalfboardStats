using HalfboardStats.Core.Builders;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Infrastructure.ServiceAgents;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Controllers
{
    public class TeamController : ITeamController
    {
        public ITeamAgent Agent { get; set; }
        public ITeamBuilder Builder { get; set; }
        public Infrastructure.Repositories.ITeamRepository Repository { get; set; }
        public TeamController(ITeamAgent agent, ITeamBuilder builder, Infrastructure.Repositories.ITeamRepository repository)
        {
            Agent = agent;
            Builder = builder;
            Repository = repository;
        }

        public async Task CreateTeamsAsync()
        {
            var teamsMapper = await Agent.GetTeamsAsync();
            var teams = Builder.BuildTeams(teamsMapper);
            await Repository.CreateTeams(teams);
        }
    }
}
