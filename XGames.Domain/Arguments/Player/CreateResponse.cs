using System;
using XGames.Domain.Interfaces.Arguments;

namespace XGames.Domain.Arguments.Player
{
    public class CreateResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
