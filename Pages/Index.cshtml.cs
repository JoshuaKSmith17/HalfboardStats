using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.ObjectRelationalMappers;
using HalfboardStats.Model.Repositories;

namespace HalfboardStats.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private StandingsMapper Standings;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGetAsync()
        {
            StandingsRepository repo = new StandingsRepository();
            Standings = await repo.GetStandings();
        }
    }
}
