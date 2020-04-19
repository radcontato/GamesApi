using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGames.Api.Controllers.Base;
using XGames.Domain.Arguments.Player;
using XGames.Domain.Interfaces.Services;
using XGames.Infra.Transactions;

namespace XGames.Api.Controllers
{
    [RoutePrefix("api/player")]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IUnitOfWork unitOfWork, IPlayerService playerService) : base(unitOfWork)
        {
            _playerService = playerService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreateRequest request)
        {

            try
            {
                var response = _playerService.Create(request);

                return await ResponseAsync(response, _playerService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("List")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            try
            {
                var response = _playerService.ListPlayers();

                return await ResponseAsync(response, _playerService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}