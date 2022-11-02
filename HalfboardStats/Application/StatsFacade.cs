using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public class StatsFacade : IStatsFacade
    {
        public IStatsRepository StatsRepository { get; set; }

        public StatsFacade(IStatsRepository repository)
        {
            StatsRepository = repository;
        }

        public async Task<List<RegularSeasonStats>> GetCurrentStatsAsync()
        {
            string currentDate = "";

            if (DateTime.Now.Month <= 9)
            {
                currentDate = (DateTime.Now.Year - 1).ToString() + DateTime.Now.Year.ToString();
            }
            else
            {
                currentDate = DateTime.Now.Year.ToString() + (DateTime.Now.Year + 1).ToString();
            }

            List<RegularSeasonStats> currentSeasonStats = await StatsRepository.GetCurrentStatsAsync(currentDate);

            return currentSeasonStats;
        }
    }
}
