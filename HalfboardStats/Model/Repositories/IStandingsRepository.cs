using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.JsonMappers;

namespace HalfboardStats.Model.Repositories
{
    interface IStandingsRepository
    {
        public Task<IStandingsMapper> GetStandings();
    }
}
