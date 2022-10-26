using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.Builders;

namespace HalfboardStats.Infrastructure.Repositories
{
    public class ActivePlayerLocalRepository : IActivePlayerLocalRepository
    {
        public IServiceProvider ServiceProvider { get; set; }
        public List<Player> Players { get; set; }

        public ActivePlayerLocalRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public async void CreateActivePlayers(HalfboardContext context)
        {

            var builder = (IPlayerbaseBuilder)ServiceProvider.GetService(typeof(IPlayerbaseBuilder));
            Players = await builder.BuildPlayers();

            //Add or update a record
            for (int i = 0; i < Players.Count; i++)
            {
                var dbPlayer = context.Players.Find(Players[i].PlayerId);
                if (dbPlayer == null)
                {
                    context.Players.Add(Players[i]);
                }
                else
                {
                    context.Entry(dbPlayer).CurrentValues.SetValues(Players[i]);
                }
            }
            context.SaveChanges();
        }

        public async void CreateAllPlayersAsync(HalfboardContext context)
        {
            var builder = (IPlayerbaseBuilder)ServiceProvider.GetService(typeof(IPlayerbaseBuilder));
            
            string rosterYear;

            if (DateTime.Now.Month <= 7)
            {
                rosterYear = (DateTime.Now.Year - 1).ToString() + DateTime.Now.Year.ToString();
            }
            else
            {
                rosterYear = DateTime.Now.Year.ToString() + (DateTime.Now.Year + 1).ToString();
            }

            while (rosterYear != "19161917")
            {
                Console.WriteLine(rosterYear);
                Players = await builder.BuildAllPlayersAsync(rosterYear);

                for (int i = 0; i < Players.Count; i++)
                {
                    var dbPlayer = context.Players.Find(Players[i].PlayerId);
                    if (dbPlayer == null)
                    {
                        context.Players.Add(Players[i]);
                    }
                    else
                    {
                        context.Entry(dbPlayer).CurrentValues.SetValues(Players[i]);
                    }
                }

                var currentYear = rosterYear.Substring(0, 4);
                int previousYear = Int32.Parse(currentYear) - 1;

                rosterYear = (previousYear).ToString() + currentYear;
            }
            context.SaveChanges();
        }

        public List<Player> GetActivePlayers(HalfboardContext context)
        {
            IQueryable<Player> playersIQ = from p in context.Players
                                           where p.IsActive == true
                                           join t in context.Teams on p.TeamId equals t.TeamId
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

            //I could use this to get it ansync with Entity Framework 6
            /*
            var playersDb = await context.Players.Where(p => p.IsActive)
                                    .Join(context.Teams,
                                        player => player.TeamId,
                                        team => team.TeamId,
                                        (player, team) => new
                                        {
                                            PlayerId = player.PlayerId,
                                            FirstName = player.FirstName,
                                            LastName = player.LastName,
                                            TeamId = player.TeamId,
                                            CurrentTeam = team,
                                            PrimaryNumber = player.PrimaryNumber,
                                            BirthDate = player.BirthDate,
                                            CurrentAge = player.CurrentAge,
                                            BirthCity = player.BirthCity
                                        })
                                    .ToListAsync();
            */

            var players = playersIQ.ToList();

            return players;
        }
    }
}
