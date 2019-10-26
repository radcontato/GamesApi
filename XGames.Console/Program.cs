using XGames.Domain.Arguments.Player;
using XGames.Domain.Services;

namespace XGames.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PlayerService();
            var request = new AuthenticateRequest();
            request.Email = "roberto@gmail.com";
            request.Senha = "asdasd";

            var response = service.Authenticate(request);

        }
    }
}
