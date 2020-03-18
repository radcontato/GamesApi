using prmToolkit.NotificationPattern;
using System;
using XGames.Domain.Enum;
using XGames.Domain.ValueObjests;

namespace XGames.Domain.Entities
{
    public class Player : Notifiable
    {
        public Player(Email email, string password)
        {
            Email = email;
            Password = password;

            new AddNotifications<Player>(this)
                .IfNotEmail(x => x.Email.Adress, "Informe um e-mail válido")
                .IfNullOrInvalidLength(x => x.Password, 6, 32, "A senha deve ter de 6 a 32 caracteres");
        }

        public Guid Id { get; set; }
        public NamePerson NamePerson { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        public StatusPlayerEnum Status { get; set; }
    }
}

