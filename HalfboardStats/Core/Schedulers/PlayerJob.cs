using HalfboardStats.Core.Controllers;
using HalfboardStats.Infrastructure.Repositories;
using Quartz;
using System;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Schedulers
{
    public class PlayerJob : IJob
    {
        public IPlayerController PlayerController { get; set; }
        public ITeamController TeamController { get; set; }
        public IPlayerStatScraperController Controller { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public PlayerJob(IPlayerController playerController,
                            ITeamController teamController,
                            IPlayerStatScraperController controller,
                            IServiceProvider serviceProvider)
        {
            PlayerController = playerController;
            TeamController = teamController;
            Controller = controller;
            ServiceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await TeamController.CreateTeamsAsync();
            await PlayerController.CreateActivePlayers();
            await Controller.ScrapePlayerSeasonStats();
        }
    }
}
