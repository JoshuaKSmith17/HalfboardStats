using HalfboardStats.Core.Builders;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Infrastructure.ServiceAgents;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Controllers
{
    public interface IPlayerStatScraperController
    {
        IPlayerRepository PlayerRepository { get; set; }
        IStatsAgent Agent { get; set; }
        ICareerStatsBuilder Builder { get; set; }
        IStatsRepository StatsRepository { get; set; }

        Task ScrapePlayerSeasonStats();
        Task ScrapePlayerStats();
    }
}