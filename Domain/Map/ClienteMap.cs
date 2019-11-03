using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("BS_001_DADOS_CLIENTE");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("ID_CLIENTE");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME");

            builder.Property(p => p.CPF)
                .HasColumnName("CPF");

            builder.Property(p => p.RG)
                .HasColumnName("RG");

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DATA_NASCIMENTO");

            builder.Property(p => p.CNH)
                .HasColumnName("CNH");

            builder.Property(p => p.LocalNascimento)
                .HasColumnName("LOCAL_NASCIMENTO");

            builder.Property(p => p.NomeMae)
                .HasColumnName("NOME_MAE");

            builder.Property(p => p.NomePai)
                .HasColumnName("NOME_PAI");

            builder.Property(p => p.TempoResidencia)
                .HasColumnName("TEMPO_RESIDENCIA");



        }
    }
}
