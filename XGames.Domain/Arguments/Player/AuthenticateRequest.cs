using XGames.Domain.Interfaces.Arguments;

namespace XGames.Domain.Arguments.Player
{
    public class AuthenticateRequest : IRequest
    {
        public string Email { get; set; }
        public string Senha{ get; set; }
    }
}
