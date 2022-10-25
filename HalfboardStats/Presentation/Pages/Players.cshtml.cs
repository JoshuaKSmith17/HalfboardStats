using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HalfboardStats.Core.Builders;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Presentation.Pages
{
    public class PlayersModel : PageModel
    {
        IServiceProvider ServiceProvider;
        HalfboardContext Context;
        public List<Player> Players { get; set; }

        public PlayersModel(IServiceProvider serviceProvider, HalfboardContext context)
        {
            ServiceProvider = serviceProvider;
            Context = context;
        }


        public void OnGet()
        {
            IQueryable<Player> playersIQ = from p in Context.Players
                                           where p.IsActive == true
                                           join t in Context.Teams on p.TeamId equals t.TeamId
                                           select new Player
                                           {
                                               PlayerId = p.PlayerId,
                                               FirstName = p.FirstName,
                                               LastName = p.LastName,
                                               TeamId = p.TeamId,
                                               CurrentTeam = t,
                                               PrimaryNumber = p.PrimaryNumber,
                                               BirthDate = p.BirthDate,
                                               CurrentAge = p.CurrentAge,
                                               BirthCity = p.BirthCity
                                           };

            Players = new List<Player>(playersIQ);

            Players.Sort((playerOne, playerTwo) => playerOne.LastName.CompareTo(playerTwo.LastName));

        }
    }
}
