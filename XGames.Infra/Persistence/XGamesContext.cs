using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGames.Domain.Entities;

namespace XGames.Infra.Persistence
{
    public class XGamesContext : DbContext
    {
        public XGamesContext() : base("XGamesConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Player> players { get; set; }
        public IDbSet<Game> games { get; set; }
        public IDbSet<ConsolePlataform> consoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
            modelBuilder.Configurations.AddFromAssembly(typeof(XGamesContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
