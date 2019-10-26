using XGames.Domain.Interfaces.Arguments;
using XGames.Domain.ValueObjests;

namespace XGames.Domain.Arguments.Player
{
    public class CreateRequest : IRequest
    {
        public NamePerson NamePerson { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
    }
}
