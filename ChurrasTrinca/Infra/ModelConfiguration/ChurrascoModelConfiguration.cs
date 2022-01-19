using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.ModelConfiguration
{
    public class ChurrascoModelConfiguration : IEntityTypeConfiguration<Churrasco>
    {
        public void Configure(EntityTypeBuilder<Churrasco> entity)
        {
            entity.ToTable("Churrasco");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Observacoes)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
