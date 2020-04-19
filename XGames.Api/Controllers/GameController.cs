using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGames.Api.Controllers.Base;
using XGames.Domain.Arguments.Game;
using XGames.Domain.Interfaces.Services;
using XGames.Infra.Transactions;

namespace XGames.Api.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;

        public GameController(IUnitOfWork unitOfWork, IGameService gameService) : base(unitOfWork)
        {
            _gameService = gameService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreateGameRequest request)
        {
            try
            {
                var response = _gameService.Create(request);

                return await ResponseAsync(response, _gameService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdateGameRequest request)
        {
            try
            {
                var response = _gameService.Update(request);

                return await ResponseAsync(response, _gameService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Authorize]
        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var response = _gameService.Delete(id);

                return await ResponseAsync(response, _gameService);
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
                var response = _gameService.ListAll();

                return await ResponseAsync(response, _gameService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}