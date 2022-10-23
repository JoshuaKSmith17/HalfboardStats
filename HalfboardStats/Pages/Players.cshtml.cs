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
                                           select p;

            IEnumerable<Team> teamsIQ = from t in Context.Teams
                                       select t;

            var teamList = teamsIQ.ToList();

            foreach(var player in playersIQ)
            {
                player.CurrentTeam = teamList.Where(t => t.TeamId == player.TeamId).FirstOrDefault();
            }

            Players = new List<Player>(playersIQ);

        }
    }
}
