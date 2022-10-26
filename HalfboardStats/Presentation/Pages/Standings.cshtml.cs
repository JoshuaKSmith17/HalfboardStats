using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using HalfboardStats.Core.Builders;

namespace HalfboardStats.Presentation.Pages
{
    public class StandingsModel : PageModel
    {
        public IDictionary<string, IEnumerable<ITeamRecord>> Standings { get; set; }

        IServiceProvider ServiceProvider;

        public StandingsModel(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public async void OnGetAsync()
        {
            StandingsBuilder builder = new StandingsBuilder(ServiceProvider);
            Standings = await builder.BuildStandings();
        }
    }
}
