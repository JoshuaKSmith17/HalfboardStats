using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public interface IPlayerFacade
    {
        Task<List<Player>> GetActivePlayers();
        IPlayer GetPlayer(int Id);
    }
}