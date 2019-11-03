using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class ReferenciaMap : IEntityTypeConfiguration<Referencia>
    {
        public void Configure(EntityTypeBuilder<Referencia> builder)
        {
            builder.ToTable("BS_006_REFERENCIA");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID_REFERENCIA");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME");

            builder.Property(p => p.Telefone)
                .HasColumnName("TELEFONE");



        }
    }
}
