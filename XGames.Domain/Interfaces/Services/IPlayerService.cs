using System.Collections.Generic;
using XGames.Domain.Arguments;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Entities;

namespace XGames.Domain.Interfaces.Services
{
    public interface IPlayerService
    {
        AuthenticateReponse Authenticate(AuthenticateRequest request);
        CreateResponse Create(CreateRequest request);
        UpdateResponse Update(UpdateRequest player);
        IEnumerable<PlayerResponse> ListPlayers();
    }
}
