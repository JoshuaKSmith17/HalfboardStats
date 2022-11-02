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
        IStatsFacade Facade;
        public IList<RegularSeasonStats> SkaterStats { get; set; }

        public PlayersModel(IStatsFacade facade)
        {
            Facade = facade;
        }

        public async Task OnGetAsync()
        {
            SkaterStats = await Facade.GetCurrentStatsAsync();

        }
    }
}
