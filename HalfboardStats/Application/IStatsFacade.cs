using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public interface IStatsFacade
    {
        public IStatsRepository StatsRepository { get; set; }
        Task<List<RegularSeasonStats>> GetCurrentStatsAsync();
    }
}