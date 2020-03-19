
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGames.Domain.Enum;
using XGames.Domain.Resources;
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

        public Player(NamePerson namePerson, Email email, string password)
        {
            NamePerson = namePerson;
            Email = email;
            Password = password;
            Id = new Guid();
            Status = StatusPlayerEnum.InProgress;

            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 32,
                   Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "3", "50"));

            if (IsValid())
            {
                //falta criptografia de senha;
            }



            AddNotifications(namePerson, email);
        }

        public Guid Id { get; private set; }
        public NamePerson NamePerson { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public StatusPlayerEnum Status { get; private set; }
    }
}

