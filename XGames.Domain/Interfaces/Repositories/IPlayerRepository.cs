using System;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Entities;

namespace XGames.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        AuthenticateReponse Authenticate(AuthenticateRequest request);
        Guid Create(Player player);
    }
}
