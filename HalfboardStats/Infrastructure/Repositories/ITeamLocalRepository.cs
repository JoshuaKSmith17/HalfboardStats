﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Infrastructure.Repositories
{
    public interface ITeamLocalRepository
    {
        public void CreateTeams();
    }
}
