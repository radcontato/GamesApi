using System;
using XGames.Domain.Entities;
using XGames.Domain.Interfaces.Repositories;
using XGames.Infra.Persistence.Repositories.Base;

namespace XGames.Infra.Persistence.Repositories
{
    public class GameRepository : BaseRepository<Game, Guid>, IGameRepository
    {
        protected readonly XGamesContext _context;

        public GameRepository(XGamesContext context) : base(context)
        {
            _context = context;
        }

    }
}
