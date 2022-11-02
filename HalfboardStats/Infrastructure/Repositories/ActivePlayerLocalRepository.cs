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
        public IPlayerbaseBuilder Builder { get; set; }
        public HalfboardContext Context { get; set; }
        public List<Player> Players { get; set; }

        public ActivePlayerLocalRepository(IPlayerbaseBuilder builder, HalfboardContext context)
        {
            Builder = builder;
            Context = context;
        }
        public async void CreateActivePlayers()
        {

            Players = await Builder.BuildPlayers();

            //Add or update a record
            for (int i = 0; i < Players.Count; i++)
            {
                var dbPlayer = Context.Players.Find(Players[i].Id);
                if (dbPlayer == null)
                {
                    Context.Players.Add(Players[i]);
                }
                else
                {
                    Context.Entry(dbPlayer).CurrentValues.SetValues(Players[i]);
                }
            }
            Context.SaveChanges();
        }

        public async void CreateAllPlayersAsync()
        {     
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
                Players = await Builder.BuildAllPlayersAsync(rosterYear);

                for (int i = 0; i < Players.Count; i++)
                {
                    var dbPlayer = Context.Players.Find(Players[i].Id);
                    if (dbPlayer == null)
                    {
                        Context.Players.Add(Players[i]);
                    }
                    else
                    {
                        Context.Entry(dbPlayer).CurrentValues.SetValues(Players[i]);
                    }
                }

                var currentYear = rosterYear.Substring(0, 4);
                int previousYear = Int32.Parse(currentYear) - 1;

                rosterYear = (previousYear).ToString() + currentYear;
            }
            Context.SaveChanges();
        }

        public List<Player> GetActivePlayers()
        {
            IQueryable<Player> playersIQ = from p in Context.Players
                                           where p.IsActive == true
                                           join t in Context.Teams on p.TeamId equals t.Id
                                           select new Player
                                           {
                                               Id = p.Id,
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
            var playersDb = await Context.Players.Where(p => p.IsActive)
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

        public List<Player> GetPlayers()
        {
            IQueryable<Player> playersIQ = from p in Context.Players                                           
                                           select p;

            return playersIQ.ToList<Player>();
        }
    }
}
