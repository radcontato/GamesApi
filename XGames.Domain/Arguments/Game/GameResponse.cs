using System;

namespace XGames.Domain.Arguments.Game
{
    public class GameResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public string Distributor { get; set; }
        public string Genre { get; set; }
        public string Site { get; set; }

        public static explicit operator GameResponse(Entities.Game game)
        {
            return new GameResponse()
            {
                Description = game.Description,
                Distributor = game.Distributor,
                Genre = game.Genre,
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Site = game.Site
            };
        }
    }
}
