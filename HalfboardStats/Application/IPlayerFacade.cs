using HalfboardStats.Core.ObjectRelationalMappers;
using System.Collections.Generic;

namespace HalfboardStats.Application
{
    public interface IPlayerFacade
    {
        List<Player> GetActivePlayers();
    }
}