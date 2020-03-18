using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGames.Domain.Resources;

namespace XGames.Domain.ValueObjests
{
    public class Email : Notifiable
    {
        public Email(string adress)
        {
            Adress = adress;

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Adress, Message.X0_INVALIDO.ToFormat("E-mail"));
        }

        public string Adress { get; private set; }

    }
}
