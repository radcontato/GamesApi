namespace XGames.Domain.Interfaces.Services
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Message = XGames.Domain.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO;
        }
        public string Message{ get; set; }
    }
}
