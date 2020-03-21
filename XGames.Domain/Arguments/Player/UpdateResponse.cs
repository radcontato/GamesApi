using System;
using XGames.Domain.Resources;

namespace XGames.Domain.Arguments.Player
{
    public class UpdateResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comments { get; set; }

        public static explicit operator UpdateResponse(Entities.Player player)
        {
            return new UpdateResponse()
            {
                Id = player.Id,
                Email = player.Email.Adress,
                FirstName = player.NamePerson.FirstName,
                LastName = player.NamePerson.LastName,
                Comments = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
