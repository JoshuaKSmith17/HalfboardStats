using HalfboardStats.Core.ObjectRelationalMappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Infrastructure.Repositories
{
    public class StatsRepository : IStatsRepository
    {

        public HalfboardContext Context { get; set; }
        public StatsRepository(HalfboardContext context)
        {
            Context = context;
        }
        public async Task CreateCareerStatsAsync(List<RegularSeasonStats> stats)
        {
            var savedStatsIQ = from r in Context.RegularSeasonStats
                               where r.PlayerId == stats[0].PlayerId
                               select r;

            foreach (var stat in stats)
            {
                if (savedStatsIQ.Any(saved => saved.Year == stat.Year) == false)
                {
                    await Context.RegularSeasonStats.AddAsync(stat);
                }
                else
                {
                    foreach(var statIQ in savedStatsIQ)
                    {
                        if (stat.Year == statIQ.Year && stat.TeamId != statIQ.TeamId)
                        {
                            await Context.RegularSeasonStats.AddAsync(stat);
                            break;
                        }
                    }
                }
            }
            try
            {
                Context.SaveChanges();
            }
            catch (SqlException) { }
        }

        public async Task<List<RegularSeasonStats>> GetCurrentStatsAsync(string currentYear)
        {

            var result = from r in Context.RegularSeasonStats
                         where r.Year == currentYear
                         join p in Context.Players on r.PlayerId equals p.Id
                         select new RegularSeasonStats
                         {
                             Id = r.Id,
                             PlayerId = p.Id,
                             Player = p,
                             Goals = r.Goals,
                             Assists = r.Assists,
                             Points = r.Points,
                             Year = r.Year,
                             Games = r.Games
                         };
            
            result = result.OrderByDescending(stat => stat.Goals);
            return await result.ToListAsync();
        }
    }
}
