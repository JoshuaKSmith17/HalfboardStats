using HalfboardStats.Core.Builders;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Infrastructure.ServiceAgents;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Controllers
{
    public interface ITeamController
    {
        ITeamAgent Agent { get; set; }
        ITeamBuilder Builder { get; set; }
        Infrastructure.Repositories.ITeamRepository Repository { get; set; }

        Task CreateTeamsAsync();
    }
}