
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGames.Domain.Entities.Base;
using XGames.Domain.Enum;
using XGames.Domain.Extensions;
using XGames.Domain.Resources;
using XGames.Domain.ValueObjests;

namespace XGames.Domain.Entities
{
    public class Player : EntityBase
    {
        public Player(Email email, string password)
        {
            Email = email;
            Password = password;

            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 32, "A senha deve ter de 6 a 32 caracteres");

            if (IsValid())
            {
                password = password.ConvertToMD5();
            }

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
                password = password.ConvertToMD5();
            }

            AddNotifications(namePerson, email);
        }

        public Guid Id { get; private set; }
        public NamePerson NamePerson { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public StatusPlayerEnum Status { get; private set; }


        public void UpdatePlayer(NamePerson name, Email email, StatusPlayerEnum status)
        {
            NamePerson = name;
            Email = email;

            new AddNotifications<Player>(this).IfFalse(status == StatusPlayerEnum.Active,
                "Só é possível alterar jogador se estiver ativo");

            AddNotifications(name, email);
        }

        public override string ToString()
        {
            return this.NamePerson.FirstName + this.NamePerson.LastName;
        }
    }
}

