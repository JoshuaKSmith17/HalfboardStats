using HalfboardStats.Core.JsonMappers.StatsMappers;
using HalfboardStats.Core.ObjectRelationalMappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Builders
{
    public interface ICareerStatsBuilder
    {
        List<RegularSeasonStats> BuildCareerStatsAsync(int Id, YearByYearMapper playerStats);
    }
}