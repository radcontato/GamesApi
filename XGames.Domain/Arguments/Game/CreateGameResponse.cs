using System;
using XGames.Domain.Resources;

namespace XGames.Domain.Arguments.Game
{
    public class CreateGameResponse
    {

        public Guid id { get; set; }
        public string Comments { get; set; }

        public static explicit operator CreateGameResponse(Entities.Game game)
        {
            return new CreateGameResponse()
            {
                id = game.Id,
                Comments = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
