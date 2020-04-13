using System;
using System.Collections.Generic;
using System.Linq;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Entities;
using XGames.Domain.Interfaces.Repositories;

namespace XGames.Infra.Persistence.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        protected readonly XGamesContext _context;

        public PlayerRepository(XGamesContext context)
        {
            _context = context;
        }

        public Player Authenticate(AuthenticateRequest request)
        {
            throw new NotImplementedException();
        }

        public Player Create(Player player)
        {
            _context.players.Add(player);
            _context.SaveChanges();

            return player;
        }

        public Player GetPlayersById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> ListPlayers()
        {
            return _context.players.ToList();
        }

        public Player Update(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
