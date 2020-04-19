using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGames.Domain.Arguments.Game;
using XGames.Domain.Entities;
using XGames.Domain.Interfaces.Repositories;
using XGames.Domain.Interfaces.Services;
using XGames.Domain.Interfaces.Services.Base;
using XGames.Domain.Resources;

namespace XGames.Domain.Services
{
    public class GameService : Notifiable, IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService()
        {

        }
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public CreateGameResponse Create(CreateGameRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("CreateRequest"));
            }


            var game = new Game(request.Name, request.Description, request.Producer, request.Distributor, request.Genre, request.Site);

            AddNotifications(game);

            if (this.IsInvalid())
            {
                return null;
            }

            game = _gameRepository.Create(game);

            return (CreateGameResponse)game;
        }

        public BaseResponse Update(UpdateGameRequest request)
        {
            if (request == null)
            {
                AddNotification("Update", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("UpdateRequest"));
            }

            var game = _gameRepository.GetById(request.Id);

            if (game == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }


            game.Update(request.Name, request.Description, request.Producer, request.Distributor, request.Genre, request.Site);

            if (IsInvalid())
            {
                return null;
            }

            _gameRepository.ToEdit(game);

            return (BaseResponse)game;


        }

        public BaseResponse Delete(Guid id)
        {
            var game = _gameRepository.GetById(id);

            if (game == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _gameRepository.Remove(game);

            return new BaseResponse()
            {
                Comments = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }

        public IEnumerable<GameResponse> ListAll()
        {
            var players = _gameRepository.List().ToList().Select(game => (GameResponse)game).ToList();

            return players;
        }
    }
}
