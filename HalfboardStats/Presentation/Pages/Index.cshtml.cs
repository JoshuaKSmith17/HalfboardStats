using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.Builders;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Core.Controllers;
using Microsoft.AspNetCore.Http;

namespace HalfboardStats.Presentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        IServiceProvider ServiceProvider;
        public IDictionary<string, IEnumerable<ITeamRecord>> Standings { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IServiceProvider serviceProvider, HalfboardContext context)
        {
            _logger = logger;
            ServiceProvider = serviceProvider;
        }
        public IActionResult OnPostBuildStats(IFormCollection data)
        {
            var controller = (IPlayerStatScraperController)ServiceProvider.GetService(typeof(IPlayerStatScraperController));
            controller.ScrapePlayerStats();
            return Page();
        }

        public IActionResult OnPostBuildPlayers(IFormCollection data)
        {
            var repo = (IActivePlayerLocalRepository)ServiceProvider.GetService(typeof(IActivePlayerLocalRepository));
            repo.CreateAllPlayersAsync();
            return Page();
        }

        public IActionResult OnPostBuildTeams(IFormCollection data)
        {
            var teamRepo = (ITeamLocalRepository)ServiceProvider.GetService(typeof(ITeamLocalRepository));
            teamRepo.CreateTeams();
            _logger.LogInformation("Teams Built");
            return Page();


        }
    }
}
