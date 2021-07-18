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
        public Standings Standings { get; set; }
        public async void OnGetAsync()
        {
            StandingsBuilder builder = new StandingsBuilder();
            Standings = await builder.BuildStandings();
        }
    }
}
