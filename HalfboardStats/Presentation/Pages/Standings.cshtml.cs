using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using HalfboardStats.Core.Builders;
using HalfboardStats.Application;

namespace HalfboardStats.Presentation.Pages
{
    public class StandingsModel : PageModel
    {
        public IDictionary<string, IEnumerable<ITeamRecord>> Standings { get; set; }
        public IStandingsFacade StandingsFacade { get; set; }

        public StandingsModel(IStandingsFacade facade)
        {
            StandingsFacade = facade;
        }
        public async Task OnGetAsync()
        {
            Standings = await StandingsFacade.GetStandings();
        }
    }
}
