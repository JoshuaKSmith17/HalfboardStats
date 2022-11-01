using HalfboardStats.Core.Builders;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Infrastructure.ServiceAgents;
using System;
using System.Threading;

namespace HalfboardStats.Core.Controllers
{
    public class PlayerStatScraperController : IPlayerStatScraperController
    {
        IServiceProvider ServiceProvider { get; set; }
        HalfboardContext Context { get; set; }

        public PlayerStatScraperController(IServiceProvider serviceProvider, HalfboardContext context)
        {
            ServiceProvider = serviceProvider;
            Context = context;
        }

        public async void ScrapePlayerStats()
        {
            /* This method will build the entire RegularSeasonStats table by querying the NHL API once per each player.
             * The method should only be run for an initial setup of the database and maybe once a year to catch any 
             * corrections.
             */
            var random = new Random();

            var repo = (IActivePlayerLocalRepository)ServiceProvider.GetService(typeof(IActivePlayerLocalRepository));
            var agent = (IYearByYearStatsAgent)ServiceProvider.GetService(typeof(IYearByYearStatsAgent));
            var builder = (ICareerStatsBuilder)ServiceProvider.GetService(typeof(ICareerStatsBuilder));
            var statsRepo = (IStatsRepository)ServiceProvider.GetService(typeof(IStatsRepository));

            var players = repo.GetPlayers(Context);
            players.Reverse();

            Context.RegularSeasonStats.RemoveRange(Context.RegularSeasonStats);
            
            foreach (var player in players)
            {
                var playerApiStats = await agent.GetCareerStats(player.Id);
                var playerStats = builder.BuildCareerStatsAsync(player.Id, playerApiStats);
                statsRepo.CreateCareerStats(playerStats);
                //Sleep thread to limit the volume of requests to the NHL API.
                Thread.Sleep(random.Next(1000, 2000));
            }
        }
    }
}
