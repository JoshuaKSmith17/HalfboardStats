using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HalfboardStats.Core.JsonMappers.PlayerMappers;

namespace HalfboardStats.Infrastructure.ServiceAgents
{
    public interface IPlayerAgent
    {
        public IHttpClientFactory Factory { get; set; }
        public Task<List<RosterPersonMapper>> GetActivePlayers();

        public Task<List<RosterPersonMapper>> GetAllPlayersAsync(string rosterYear);
    }
}
