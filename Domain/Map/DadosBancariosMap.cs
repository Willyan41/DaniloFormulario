using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class DadosBancariosMap : IEntityTypeConfiguration<DadosBancarios>
    {
        public void Configure(EntityTypeBuilder<DadosBancarios> builder)
        {
            builder.ToTable("BS_005_DADOS_BANCARIOS");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID_DADOS_BANCARIOS");

            builder.Property(p => p.CodigoBanco)
                .HasColumnName("CODIGO_BANCO");

            builder.Property(p => p.Banco)
                .HasColumnName("BANCO");

            builder.Property(p => p.Agencia)
                .HasColumnName("AGENCIA");

            builder.Property(p => p.Conta)
                .HasColumnName("CONTA");

            builder.Property(p => p.TempoConta)
                .HasColumnName("TEMPO_CONTA");

            builder.Property(p => p.Obs)
                .HasColumnName("OBS");





        }


    }
}
