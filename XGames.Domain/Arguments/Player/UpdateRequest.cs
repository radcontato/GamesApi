using System;

namespace XGames.Domain.Arguments.Player
{
    public class UpdateRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
