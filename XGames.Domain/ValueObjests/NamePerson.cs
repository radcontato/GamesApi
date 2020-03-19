using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGames.Domain.Resources;

namespace XGames.Domain.ValueObjests
{
    public class NamePerson : Notifiable
    {
        public NamePerson(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<NamePerson>(this)
                .IfNullOrInvalidLength(x => x.FirstName, 3, 50,
                Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Primeiro Nome", "3", "50"))
                .IfNullOrInvalidLength(x => x.LastName, 3, 50,
                Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Ultimo Nome", "3", "50"));

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
