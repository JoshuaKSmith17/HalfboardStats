using System.Collections.Generic;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers;

namespace HalfboardStats.Infrastructure.Repositories
{
    public interface IPlayerRepository
    {
        HalfboardContext Context { get; set; }
        Task CreateOrUpdateAsync(List<Player> players);
        Task<List<Player>> Get(bool isActive);
        Player Get(int playerId);
        List<Player> GetAll();
    }
}
