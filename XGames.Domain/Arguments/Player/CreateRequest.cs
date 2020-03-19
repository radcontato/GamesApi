using XGames.Domain.Interfaces.Arguments;
using XGames.Domain.ValueObjests;

namespace XGames.Domain.Arguments.Player
{
    public class CreateRequest : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
