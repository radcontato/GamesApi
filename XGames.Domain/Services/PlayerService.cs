using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Entities;
using XGames.Domain.Interfaces.Repositories;
using XGames.Domain.Interfaces.Services;
using XGames.Domain.Resources;
using XGames.Domain.ValueObjests;

namespace XGames.Domain.Services
{
    public class PlayerService : Notifiable, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService()
        {

        }

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public CreateResponse Create(CreateRequest request)
        {

            var namePerson = new NamePerson(request.FirstName, request.LastName);
            var email = new Email(request.Email);
            var password = request.PassWord;

            var player = new Player(namePerson, email, password);


            if (IsInvalid())
            {
                return null;
            }

            player = _playerRepository.Create(player);

            return (CreateResponse)player;
        }

        public AuthenticateReponse Authenticate(AuthenticateRequest request)
        {
            if (request == null)
            {
                AddNotification("AuthenticateRequest", Message.X0_E_OBRIGATORIO.ToFormat("AuthenticateRequest"));
            }


            var email = new Email(request.Email);
            var player = new Player(email, request.Password);

            AddNotifications(player);

            if (player.IsInvalid())
            {
                return null;
            }

            player = _playerRepository.Authenticate(request);

            return (AuthenticateReponse)player;
        }

        public UpdateResponse Update(UpdateRequest player)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<PlayerResponse> listPlayers()
        {
            return _playerRepository.ListPlayers().ToList().Select(player => (PlayerResponse)player).ToList();
        }
    }
}
