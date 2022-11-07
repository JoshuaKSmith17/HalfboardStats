﻿using HalfboardStats.Core.Builders;
using HalfboardStats.Core.JsonMappers.PlayerMappers;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Infrastructure.ServiceAgents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Controllers
{
    public class PlayerController : IPlayerController
    {
        public IPlayerRepository Repository { get; set; }
        public IPlayerbaseBuilder Builder { get; set; }
        public IPlayerAgent Agent { get; set; }
        public ISeasonYear SeasonYear { get; set; }

        public PlayerController(IPlayerRepository repository, IPlayerbaseBuilder builder, IPlayerAgent agent, ISeasonYear seasonYear)
        {
            Repository = repository;
            Builder = builder;
            Agent = agent;
            SeasonYear = seasonYear;
        }

        public async Task<List<Player>> GetActivePlayers()
        {
            return await Repository.Get(true);
        }

        public async Task CreateActivePlayers()
        {
            List<RosterPersonMapper> rosterPersons = await Agent.GetActivePlayers();
            List<Player> players = Builder.Build(rosterPersons);
            await Repository.CreateOrUpdateAsync(players);
        }

        public async Task CreateAllPlayers()
        {
            while(SeasonYear.Year != SeasonYear.FirstYear)
            {
                List<RosterPersonMapper> rosterPersons = await Agent.GetAllPlayersAsync(SeasonYear.Year);
                List<Player> players = Builder.Build(rosterPersons);
                await Repository.CreateOrUpdateAsync(players);
                SeasonYear.DecrementSeason();
            }
            
        }
    }
}