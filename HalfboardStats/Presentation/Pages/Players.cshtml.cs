using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HalfboardStats.Core.Builders;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Application;

namespace HalfboardStats.Presentation.Pages
{
    public class PlayersModel : PageModel
    {
        IServiceProvider ServiceProvider;
        HalfboardContext Context;
        IPlayerFacade Facade;
        public List<Player> Players { get; set; }

        public PlayersModel(IServiceProvider serviceProvider, HalfboardContext context)
        {
            ServiceProvider = serviceProvider;
            Context = context;
            Facade = (IPlayerFacade)ServiceProvider.GetService(typeof(IPlayerFacade));
        }


        public void OnGet()
        {
            Players = Facade.GetActivePlayers();
            
            Players.Sort((playerOne, playerTwo) => playerOne.LastName.CompareTo(playerTwo.LastName));

        }
    }
}
