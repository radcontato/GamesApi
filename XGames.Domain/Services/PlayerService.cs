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
            if (request == null)
            {
                throw new Exception("Request Vazio.");
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Informe um e-mail.");
            }

            if (isEmail(request.Email))
            {
                throw new Exception("Informe um e-mail válido.");
            }

            if (string.IsNullOrEmpty(request.Senha))
            {
                throw new Exception("Informe uma senha.");
            }

            if (request.Senha.Length < 6)
            {
                throw new Exception("Informe uma senha com mais que 6 caracteres.");
            }

            var response = _playerRepository.Authenticate(request);

            return response;
        }

        private bool isEmail(string email)
        {
            return false;
        }
    }
}
