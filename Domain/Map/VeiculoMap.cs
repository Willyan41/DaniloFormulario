using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("BS_007_VEICULO");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID_VEICULO");

            builder.Property(p => p.NomeVeiculo)
                .HasColumnName("NOME_VEICULO");

            builder.Property(p => p.Valor)
                .HasColumnName("VALOR");



        }




    }
}
