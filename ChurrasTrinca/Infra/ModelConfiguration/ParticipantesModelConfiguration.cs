using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.ModelConfiguration
{
    public class ParticipantesModelConfiguration : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ValorContribuicao).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Churrasco)
                .WithMany(p => p.Participantes)
                .HasForeignKey(d => d.ChurrascoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participantes_Churrasco");
        }
    }
}
