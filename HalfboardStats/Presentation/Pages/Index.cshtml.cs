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
        public IDictionary<string, IEnumerable<ITeamRecord>> Standings { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IServiceProvider serviceProvider, HalfboardContext context)
        {
            _logger = logger;
        }
    }
}
