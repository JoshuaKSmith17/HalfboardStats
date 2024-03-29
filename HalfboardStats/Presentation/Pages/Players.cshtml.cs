using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Application;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HalfboardStats.Presentation.Pages
{
    public class PlayersModel : PageModel
    {
        IStatsFacade Facade;
        public IList<RegularSeasonStats> SkaterStats { get; set; }
        [BindProperty]
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; } = 50;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        
        public PlayersModel(IStatsFacade facade)
        {
            Facade = facade; 
        }

        public async Task OnGetAsync(int currentPage)
        {
            if (currentPage == 0)
            {
                CurrentPage = 1;
            }
            else
            {
                CurrentPage = currentPage;
            }
            SkaterStats = await Facade.GetPaginatedResultsAsync(CurrentPage, PageSize);
            Count = await Facade.GetCountAsync();         
        }
    }
}
