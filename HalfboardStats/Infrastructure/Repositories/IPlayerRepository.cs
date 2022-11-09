using System.Collections.Generic;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;

namespace HalfboardStats.Infrastructure.Repositories
{
    public interface IPlayerRepository
    {
        HalfboardContext Context { get; set; }
        Task CreateOrUpdateAsync(List<IPlayer> players);
        Task<List<Player>> Get(bool isActive);
        IPlayer Get(int playerId);
        List<Player> GetAll();
    }
}
