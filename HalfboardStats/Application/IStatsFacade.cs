using HalfboardStats.Core.ObjectRelationalMappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public interface IStatsFacade
    {
        HalfboardContext Context { get; set; }
        IServiceProvider ServiceProvider { get; set; }

        Task<List<RegularSeasonStats>> GetCurrentStatsAsync();
    }
}