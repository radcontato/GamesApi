using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
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
            Guid id = _playerRepository.Create(request);
            return new CreateResponse() { Id = id, Message = "OOperation successfully" };
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

            var response = _playerRepository.Authenticate(request);

            return response;
        }
    }
}
