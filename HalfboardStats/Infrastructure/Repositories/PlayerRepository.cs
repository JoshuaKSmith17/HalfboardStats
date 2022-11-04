﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;
using Microsoft.EntityFrameworkCore;

namespace HalfboardStats.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public HalfboardContext Context { get; set; }

        public PlayerRepository(HalfboardContext context)
        {
            Context = context;
        }
        public async Task CreateOrUpdateAsync(List<Player> players)
        {
            //Add or update a record
            foreach (var player in players)
            {
                var dbPlayer = Context.Players.Find(player.Id);
                if (dbPlayer == null)
                {
                    Context.Players.Add(player);
                }
                else
                {
                    Context.Entry(dbPlayer).CurrentValues.SetValues(player);
                }
            }
            await Context.SaveChangesAsync();
        }

        public async Task<List<Player>> Get(bool isActive = true)
        {
            IQueryable<Player> playersIQ = from p in Context.Players
                                           where p.IsActive == isActive
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

            var players = await playersIQ.ToListAsync();
            return players;
        }

        public List<Player> GetAll()
        {
            IQueryable<Player> playersIQ = from p in Context.Players                                           
                                           select p;

            return playersIQ.ToList();
        }
    }
}
