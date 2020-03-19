using System;
using System.Linq;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Services;

namespace XGames.ConsoleAplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PlayerService();

            var request = new AuthenticateRequest();
            request.Email = "roberto@gmail.com";
            request.Password = "123456789";

            var response = service.Authenticate(request);

            var requestADDPlayer = new CreateRequest()
            {
                FirstName = "Roberto",
                LastName = "Junior",
                Email = "roberto.albano@nibo.com.br",
                PassWord = "123456"
            };

            var response2 = service.Create(requestADDPlayer);



            Console.WriteLine("Serviço é valido => " + service.IsValid());

            service.Notifications.ToList().ForEach(
                x => Console.WriteLine(x.Message));

            Console.ReadKey();
        }
    }
}
