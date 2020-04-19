using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Entities;
using XGames.Domain.Interfaces.Repositories;
using XGames.Domain.Interfaces.Services;
using XGames.Domain.Interfaces.Services.Base;
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
            if(request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("CreateRequest"));
            }

            var namePerson = new NamePerson(request.FirstName, request.LastName);
            var email = new Email(request.Email);
            var password = request.PassWord;

            var player = new Player(namePerson, email, password);

            AddNotifications(namePerson, email);

            var playerExist = _playerRepository.Exists(x => x.Email.Adress == request.Email);

            if (playerExist)
            {
                AddNotification("E-mail", Message.JA_EXISTE_UM_X0_CHAMADO_X1.ToFormat("e-mail", request.Email));
            }

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

            player = _playerRepository.GetBy(x => x.Email.Adress == player.Email.Adress &&  x.Password == player.Password);

            return (AuthenticateReponse)player;
        }
        public UpdateResponse Update(UpdateRequest request)
        {
            if (request == null)
            {
                AddNotification("UpdateRequest", Message.X0_E_OBRIGATORIO.ToFormat("UpdateRequest"));
            }

            var player = _playerRepository.GetById(request.Id);

            if (player == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
            }

            var name = new NamePerson(request.FirstName, request.LastName);
            var email = new Email(request.Email);

            player.UpdatePlayer(name, email, player.Status);

            AddNotifications(player);

            if (player.IsInvalid())
            {
                return null;
            }

            _playerRepository.ToEdit(player);

            return (UpdateResponse)player;
        }
        public IEnumerable<PlayerResponse> ListPlayers()
        {

            var players = _playerRepository.List().ToList().Select(player => (PlayerResponse)player).ToList();

            return players;

        }
        public BaseResponse Delete(Guid id)
        {
            Player player = _playerRepository.GetById(id);

            if (player == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _playerRepository.Remove(player);

            return new BaseResponse();
        }
    }
}
