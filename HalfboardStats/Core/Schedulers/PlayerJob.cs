using HalfboardStats.Core.Controllers;
using HalfboardStats.Infrastructure.Repositories;
using Quartz;
using System;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Schedulers
{
    public class PlayerJob : IJob
    {
        public IActivePlayerLocalRepository Repository { get; set; }
        public ITeamLocalRepository TeamLocalRepository { get; set; }
        public IPlayerStatScraperController Controller { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public PlayerJob(IActivePlayerLocalRepository repository,
                            ITeamLocalRepository teamLocalRepository,
                            IPlayerStatScraperController controller,
                            IServiceProvider serviceProvider)
        {
            Repository = repository;
            TeamLocalRepository = teamLocalRepository;
            Controller = controller;
            ServiceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            TeamLocalRepository.CreateTeams();
            await Repository.CreateActivePlayers();
            await Controller.ScrapePlayerSeasonStats();
        }
    }
}
