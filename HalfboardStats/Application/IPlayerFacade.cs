using HalfboardStats.Core.ObjectRelationalMappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HalfboardStats.Application
{
    public interface IPlayerFacade
    {
        Task<List<Player>> GetActivePlayers();
    }
}