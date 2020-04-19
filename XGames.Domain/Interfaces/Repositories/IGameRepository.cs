using System;
using XGames.Domain.Entities;
using XGames.Domain.Interfaces.Repositories.Base;

namespace XGames.Domain.Interfaces.Repositories
{
    public interface IGameRepository : IBaseRepository<Game, Guid>
    {
    }
}
