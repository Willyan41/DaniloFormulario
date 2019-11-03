using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("BS_002_ENDERECO");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID_ENDERECO");

            builder.Property(p => p.Endereco1)
                .HasColumnName("ENDERECO");

            builder.Property(p => p.CEP)
                .HasColumnName("CEP");

            builder.Property(p => p.TempoResidencia)
                .HasColumnName("TEMPO_RESIDENCIA");

        }


    }
}
