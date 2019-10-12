using System;

namespace XGames.Domain.Entities
{
    class MyGame
    {
        public Guid Id { get; set; }
        public GameConsole GameConsole { get; set; }
        public bool Wish { get; set; }
        public DateTime wishDate { get; set; }
        public bool Change { get; set; }
        public bool Sell { get; set; }
    }
}
