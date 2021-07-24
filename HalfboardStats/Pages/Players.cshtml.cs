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
    public class PlayersModel : PageModel
    {
        IServiceProvider ServiceProvider;
        public List<Player> Players { get; set; }

        public PlayersModel(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }


        public async void OnGetAsync()
        {
            var builder = (IPlayerbaseBuilder)ServiceProvider.GetService(typeof(IPlayerbaseBuilder));
            Players = await builder.BuildPlayers();
        }
    }
}
