using System;
using XGames.Domain.ValueObjests;

namespace XGames.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public NamePerson NamePerson { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }
    }
}
