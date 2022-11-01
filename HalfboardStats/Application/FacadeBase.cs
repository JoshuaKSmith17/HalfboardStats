using HalfboardStats.Core.ObjectRelationalMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public abstract class FacadeBase
    {
        public IServiceProvider ServiceProvider { get; set; }
        public HalfboardContext Context { get; set; }

        public FacadeBase(IServiceProvider serviceProvider, HalfboardContext context)
        {
            ServiceProvider = serviceProvider;
            Context = context;
        }
    }
}
