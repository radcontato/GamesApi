using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using XGames.Domain.Entities;

namespace XGames.Infra.Persistence.Map
{
    public class MapPlayer : EntityTypeConfiguration<Player>
    {
        public MapPlayer()
        {
            ToTable("Player");

            Property(p => p.Email.Adress)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_JOGADOR_EMAIL") { IsUnique = true }))
                .HasColumnName("Email");

            Property(p => p.NamePerson.FirstName).HasMaxLength(50).IsRequired().HasColumnName("FirstName");
            Property(p => p.NamePerson.LastName).HasMaxLength(50).IsRequired().HasColumnName("LastName");
            Property(p => p.Password).IsRequired();
            Property(p => p.Status).IsRequired();
        }
    }
}
