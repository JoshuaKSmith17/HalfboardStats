using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Infrastructure.Repositories
{
    interface ITeamLocalRepository
    {
        public void CreateTeams(HalfboardContext context);
    }
}
