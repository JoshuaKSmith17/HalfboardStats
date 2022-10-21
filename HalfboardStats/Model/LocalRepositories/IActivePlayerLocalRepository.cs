using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.ObjectRelationalMappers;

namespace HalfboardStats.Model.LocalRepositories
{
    interface IActivePlayerLocalRepository
    {
        public void CreateActivePlayers(HalfboardContext context);
    }
}
