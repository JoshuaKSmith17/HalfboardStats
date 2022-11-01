using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Application;
using System.Threading.Tasks;

namespace HalfboardStats.Presentation.Pages
{
    public class PlayersModel : PageModel
    {
        IServiceProvider ServiceProvider;
        HalfboardContext Context;
        IStatsFacade Facade;
        public List<RegularSeasonStats> SkaterStats { get; set; }

        public PlayersModel(IServiceProvider serviceProvider, HalfboardContext context)
        {
            ServiceProvider = serviceProvider;
            Context = context;
            Facade = (IStatsFacade)ServiceProvider.GetService(typeof(IStatsFacade));
        }


        public async Task OnGetAsync()
        {
            SkaterStats = await Facade.GetCurrentStatsAsync();

        }
    }
}
