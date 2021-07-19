using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.Builders;
using HalfboardStats.Model.ObjectRelationalMappers;

namespace HalfboardStats.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        IServiceProvider ServiceProvider;
        public Dictionary<string, IEnumerable<TeamRecord>> Standings { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            ServiceProvider = serviceProvider;
        }

        public async void OnGetAsync()
        {
            StandingsBuilder builder = new StandingsBuilder(ServiceProvider);
            Standings = await builder.BuildStandings();
        }
    }
}
