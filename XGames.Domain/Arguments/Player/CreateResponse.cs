using System;
using XGames.Domain.Interfaces.Arguments;
using XGames.Domain.Resources;

namespace XGames.Domain.Arguments.Player
{
    public class CreateResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Comments { get; set; }

        public static explicit operator CreateResponse(Entities.Player player)
        {
            return new CreateResponse()
            {
                Id = player.Id,
                Comments = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
