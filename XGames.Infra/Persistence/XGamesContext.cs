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
        public IDbSet<Console> consoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remova a plurarização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar varchar e não nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

          
            //Adiciona entidades mapeadas - Automaticamente via assrmbly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGamesContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
