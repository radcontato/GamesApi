using XGames.Domain.Arguments.Console;

namespace XGames.Domain.Interfaces.Services
{
    public interface IConsoleService
    {
        CreateResponse Create(CreateRequest request);
    }
}
