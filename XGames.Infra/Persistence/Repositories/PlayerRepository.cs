using System;
using XGames.Domain.Entities;
using XGames.Domain.Interfaces.Repositories;
using XGames.Infra.Persistence.Repositories.Base;

namespace XGames.Infra.Persistence.Repositories
{
    public class PlayerRepository : BaseRepository<Player, Guid>, IPlayerRepository
    {
        protected readonly XGamesContext _context;

        public PlayerRepository(XGamesContext context) : base(context)
        {
            _context = context;
        }
    }
}
