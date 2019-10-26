using XGames.Domain.Interfaces.Arguments;

namespace XGames.Domain.Arguments.Player
{
    public class AuthenticateReponse : IResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
