using HalfboardStats.Core.Builders;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Infrastructure.ServiceAgents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Controllers
{
    public interface IPlayerController
    {
        IPlayerAgent Agent { get; set; }
        IPlayerbaseBuilder Builder { get; set; }
        IPlayerRepository Repository { get; set; }

        Task<List<Player>> GetActivePlayers();
        Task CreateActivePlayers();
        IPlayer Get(int Id);
    }
}