using System;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Interfaces.Repositories;
using XGames.Domain.Interfaces.Services;

namespace XGames.Domain.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

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

            throw new NotImplementedException();
        }


    }
}
