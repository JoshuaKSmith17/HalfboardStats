using HalfboardStats.Core.ObjectRelationalMappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Infrastructure.Repositories
{
    public interface IStatsRepository
    {
        HalfboardContext Context { get; set; }
        IServiceProvider ServiceProvider { get; set; }

        void CreateCareerStats(List<RegularSeasonStats> stats);
        Task<List<RegularSeasonStats>> GetCurrentStatsAsync(string currentYear);
    }
}