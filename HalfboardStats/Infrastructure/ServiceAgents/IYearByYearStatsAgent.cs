using HalfboardStats.Core.JsonMappers.StatsMappers;
using System;
using System.Threading.Tasks;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public interface IYearByYearStatsAgent
    {
        IServiceProvider ServiceProvider { get; set; }

        Task<YearByYearMapper> GetCareerStats(int Id);
    }
}