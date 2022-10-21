﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.Builders;
using HalfboardStats.Model.ObjectRelationalMappers;
using HalfboardStats.Model.LocalRepositories;

namespace HalfboardStats.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        IServiceProvider ServiceProvider;
        HalfboardContext Context;
        public IDictionary<string, IEnumerable<ITeamRecord>> Standings { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IServiceProvider serviceProvider, HalfboardContext context)
        {
            _logger = logger;
            ServiceProvider = serviceProvider;
            Context = context;
        }

        public async void OnGetAsync()
        {
            StandingsBuilder builder = new StandingsBuilder(ServiceProvider);
            Standings = await builder.BuildStandings();        }

        public void OnPost()
        {
            var repo = (IActivePlayerLocalRepository)ServiceProvider.GetService(typeof(IActivePlayerLocalRepository));
            repo.CreateActivePlayers(Context);

            var teamRepo = (ITeamLocalRepository)ServiceProvider.GetService(typeof(ITeamLocalRepository));
            teamRepo.CreateTeams(Context);
        }
    }
}
