using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.ObjectRelationalMappers;

namespace HalfboardStats.Model.LocalRepositories
{
    interface ITeamLocalRepository
    {
        public void CreateTeams(HalfboardContext context);
    }
}
