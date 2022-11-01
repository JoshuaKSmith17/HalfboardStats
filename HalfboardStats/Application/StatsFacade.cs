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
        public IServiceProvider ServiceProvider { get; set; }
        public HalfboardContext Context { get; set; }
        public StatsFacade(IServiceProvider serviceProvider, HalfboardContext context)
        {
            ServiceProvider = serviceProvider;
            Context = context;
        }

        public async Task<List<RegularSeasonStats>> GetCurrentStatsAsync()
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

            var repo = (IStatsRepository)ServiceProvider.GetService(typeof(IStatsRepository));
            List<RegularSeasonStats> currentSeasonStats = await repo.GetCurrentStatsAsync(currentDate);

            return currentSeasonStats;
        }
    }
}
