using HalfboardStats.Core;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.Repositories;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public class StatsFacade : IStatsFacade
    {
        public IStatsRepository StatsRepository { get; set; }
        public ISeasonYear Year { get; set; }

        public StatsFacade(IStatsRepository repository, ISeasonYear year)
        {
            StatsRepository = repository;
            Year = year;
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

        public async Task<List<RegularSeasonStats>> GetPaginatedResultsAsync(int currentPage, int pageSize, string sortBy)
        {
            List<RegularSeasonStats> currentSeasonStats = await GetCurrentResults();
            return currentSeasonStats.AsQueryable().OrderBy(sortBy).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<int> GetCountAsync()
        {
            var stats = await GetCurrentResults();
            return stats.Count;
        }

        private async Task<List<RegularSeasonStats>> GetCurrentResults()
        {
            return await StatsRepository.GetCurrentStatsAsync(Year.Year);
        }
    }
}
