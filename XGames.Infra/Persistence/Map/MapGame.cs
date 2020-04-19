using System.Data.Entity.ModelConfiguration;
using XGames.Domain.Entities;

namespace XGames.Infra.Persistence.Map
{
    public class MapGame : EntityTypeConfiguration<Game>
    {
        public MapGame()
        {
            ToTable("Game");

            Property(p => p.Name).HasMaxLength(100).IsRequired();
            Property(p => p.Description).HasMaxLength(255).IsRequired();
            Property(p => p.Producer).HasMaxLength(50);
            Property(p => p.Distributor).HasMaxLength(50);
            Property(p => p.Genre).HasMaxLength(30).IsRequired();
            Property(p => p.Site).HasMaxLength(200);
        }
    }
}
