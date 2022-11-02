using HalfboardStats.Core.JsonMappers.StatsMappers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public interface IYearByYearStatsAgent
    {
        IHttpClientFactory ClientFactory { get; set; }
        Task<YearByYearMapper> GetCareerStats(int Id);
    }
}