using System;
using XGames.Domain.Arguments.Player;

namespace XGames.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        AuthenticateReponse Authenticate(AuthenticateRequest request);
        Guid Create(CreateRequest request);
    }
}
