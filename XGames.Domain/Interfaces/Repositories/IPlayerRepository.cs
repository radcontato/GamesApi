using System;
using System.Collections;
using System.Collections.Generic;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Entities;

namespace XGames.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Player Authenticate(AuthenticateRequest request);
        Player Create(Player player);
        Player Update(Player player);
        IEnumerable<Player> ListPlayers();
    }
}
