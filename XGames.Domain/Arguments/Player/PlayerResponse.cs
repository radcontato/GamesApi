using System;

namespace XGames.Domain.Arguments.Player
{
    public class PlayerResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameComplete { get; set; }
        public string Status { get; set; }

        public static explicit operator PlayerResponse(Entities.Player player)
        {
            return new PlayerResponse()
            {
                Id = player.Id,
                Email = player.Email.Adress,
                FirstName = player.NamePerson.FirstName,
                LastName = player.NamePerson.LastName,
                NameComplete = player.ToString()
              //  Status = player.Status.ToString()                
            };
        }
    }
}
