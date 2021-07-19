using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HalfboardStats.Model.ObjectRelationalMappers;
using HalfboardStats.Model.Builders;

namespace HalfboardStats.Pages
{
    public class StandingsModel : PageModel
    {
        public Dictionary<string, IEnumerable<TeamRecord>> Standings { get; set; }

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
