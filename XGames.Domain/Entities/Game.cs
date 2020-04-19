using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGames.Domain.Entities.Base;
using XGames.Domain.Resources;

namespace XGames.Domain.Entities
{
    public class Game : EntityBase
    {

        protected Game()
        {

        }
        public Game(string name, string description, string producer, string distributor, string genre, string site)
        {
            Name = name;
            Description = description;
            Producer = producer;
            Distributor = distributor;
            Genre = genre;
            Site = site;

            Validate();
        }

        public void Update(string name, string description, string producer, string distributor, string genre, string site)
        {
            Name = name;
            Description = description;
            Producer = producer;
            Distributor = distributor;
            Genre = genre;
            Site = site;

            Validate();


        }

        private void Validate()
        {
            new AddNotifications<Game>(this)
               .IfNullOrInvalidLength(x => x.Name, 1, 100, Message.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES.ToFormat("Nome", "1", "100"))
               .IfNullOrInvalidLength(x => x.Description, 1, 255, Message.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES.ToFormat("Descrição", "1", "255"))
               .IfNullOrInvalidLength(x => x.Genre, 1, 30, Message.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES.ToFormat("Genero", "1", "30"));
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Producer { get; private set; }
        public string Distributor { get; private set; }
        public string Genre { get; private set; }
        public string Site { get; private set; }
    }
}
