using System.Data.Entity.ModelConfiguration;
using XGames.Domain.Entities;

namespace XGames.Infra.Persistence.Map
{
    public class MapConsole : EntityTypeConfiguration<ConsolePlataform>
    {
        public MapConsole()
        {
            ToTable("ConsolePlataform");

            Property(c => c.Nome).HasMaxLength(50).IsRequired();
        }
    }
}
