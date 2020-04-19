using System;
using System.Collections.Generic;
using XGames.Domain.Arguments.Game;
using XGames.Domain.Interfaces.Services.Base;

namespace XGames.Domain.Interfaces.Services
{
    public interface IGameService : IBaseService
    {
        CreateGameResponse Create(CreateGameRequest request);

        BaseResponse Update(UpdateGameRequest request);

        BaseResponse Delete(Guid id);

        IEnumerable<GameResponse> ListAll();
    }
}
