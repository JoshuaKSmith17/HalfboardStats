using HalfboardStats.Core.JsonMappers.StatsMappers;
using HalfboardStats.Core.ObjectRelationalMappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Builders
{
    public interface ICareerStatsBuilder
    {
        IServiceProvider ServiceProvider { get; set; }

        List<RegularSeasonStats> BuildCareerStatsAsync(int Id, YearByYearMapper playerStats);
    }
}