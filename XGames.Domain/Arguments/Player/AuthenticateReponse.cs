using System;
using XGames.Domain.Interfaces.Arguments;

namespace XGames.Domain.Arguments.Player
{
    public class AuthenticateReponse : IResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AuthenticateReponse(Entities.Player player)
        {
            return new AuthenticateReponse()
            {
                Name = player.NamePerson.FirstName,
                Email = player.Email.Adress,
                Status = (int)player.Status
            };
        }      
    }
}
