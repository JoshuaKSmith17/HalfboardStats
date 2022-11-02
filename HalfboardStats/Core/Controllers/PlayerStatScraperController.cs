using HalfboardStats.Core.Builders;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Infrastructure.ServiceAgents;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Controllers
{
    public class PlayerStatScraperController : IPlayerStatScraperController
    {
        public IActivePlayerLocalRepository PlayerRepository { get; set; }
        public IYearByYearStatsAgent Agent { get; set; }
        public ICareerStatsBuilder Builder { get; set; }
        public IStatsRepository StatsRepository { get; set; }

        public PlayerStatScraperController(IActivePlayerLocalRepository playerRepository, IYearByYearStatsAgent agent, ICareerStatsBuilder builder, IStatsRepository statsRepository)
        {
            PlayerRepository = playerRepository;
            Agent = agent;
            Builder = builder;
            StatsRepository = statsRepository;
        }

        public async Task ScrapePlayerStats()
        {
            /* This method will build the entire RegularSeasonStats table by querying the NHL API once per each player.
             * The method should only be run for an initial setup of the database and maybe once a year to catch any 
             * corrections.
             */
            var random = new Random();

            List<Player> players = PlayerRepository.GetPlayers();
            players.Reverse();

            //Context.RegularSeasonStats.RemoveRange(Context.RegularSeasonStats);
            
            foreach (var player in players)
            {
                var playerApiStats = await Agent.GetCareerStats(player.Id);
                var playerStats = Builder.BuildCareerStatsAsync(player.Id, playerApiStats);
                await StatsRepository.CreateCareerStatsAsync(playerStats);
                //Sleep thread to limit the volume of requests to the NHL API.
                //Thread.Sleep(random.Next(1000, 2000));
            }
        }
    }
}
