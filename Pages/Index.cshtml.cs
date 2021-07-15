﻿using Microsoft.AspNetCore.Mvc;
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
        private Standings Standings;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGetAsync()
        {
            StandingsBuilder builder = new StandingsBuilder();
            Standings = await builder.BuildStandings();
        }
    }
}
