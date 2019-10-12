using System;

namespace XGames.Domain.Entities
{
    public class GameConsole
    {
        public Guid Id { get; set; }
        public Game Game { get; set; }
        public Console Console { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
