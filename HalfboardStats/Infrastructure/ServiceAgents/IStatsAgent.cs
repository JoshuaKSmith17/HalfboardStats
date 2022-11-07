using HalfboardStats.Core.JsonMappers.StatsMappers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public interface IStatsAgent
    {
        IHttpClientFactory ClientFactory { get; set; }
        Task<YearByYearMapper> GetCareerStats(int Id);
        Task<YearByYearMapper> GetSeasonStats(int Id);
    }
}