using HalfboardStats.Core.ObjectRelationalMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public class TeamFacade : FacadeBase
    {
        public IServiceProvider ServiceProvider { get; set; }
        public HalfboardContext Context { get; set; }

        public TeamFacade(IServiceProvider serviceProvider, HalfboardContext context) : base(serviceProvider, context)
        {

        }
    }
}
