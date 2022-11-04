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
            List<RegularSeasonStats> currentSeasonStats = await GetCurrentResults();

            return currentSeasonStats;
        }

        public async Task<List<RegularSeasonStats>> GetPaginatedResultsAsync(int currentPage, int pageSize)
        {
            List<RegularSeasonStats> currentSeasonStats = await GetCurrentResults();

            return currentSeasonStats.OrderByDescending(s => s.Points).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<int> GetCountAsync()
        {
            var stats = await GetCurrentResults();
            return stats.Count;
        }

        private async Task<List<RegularSeasonStats>> GetCurrentResults()
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

            return await StatsRepository.GetCurrentStatsAsync(currentDate);
        }
    }
}
