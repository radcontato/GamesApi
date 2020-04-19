using System;
using XGames.Domain.Entities;
using XGames.Domain.Resources;

namespace XGames.Domain.Interfaces.Services.Base
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Comments = XGames.Domain.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO;
        }
        public string Comments { get; set; }

        public static explicit operator BaseResponse(Game game)
        {
            return new BaseResponse()
            {
                Comments = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
