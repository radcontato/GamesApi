using XGames.Domain.Arguments;
using XGames.Domain.Arguments.Player;

namespace XGames.Domain.Interfaces.Services
{
    public interface IPlayerService
    {
        AuthenticateReponse Authenticate(AuthenticateRequest request);
        CreateResponse Create(CreateRequest request);
    }
}
