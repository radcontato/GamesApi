using System;
using System.Collections.Generic;
using XGames.Domain.Arguments.Player;

namespace XGames.Domain.Interfaces.Services
{
    public interface IPlayerService : IBaseService
    {
        AuthenticateReponse Authenticate(AuthenticateRequest request);
        CreateResponse Create(CreateRequest request);
        UpdateResponse Update(UpdateRequest player);
        IEnumerable<PlayerResponse> ListPlayers();
        BaseResponse Delete(Guid id);
    }
}
