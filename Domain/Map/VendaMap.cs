using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("BS_008_VENDA");
            //builder.HasKey(k => new { k.IdCliente, k.IdVeiculo });

            builder.Property(p => p.IdCliente)
                .HasColumnName("ID_CLIENTE");

            builder.Property(p => p.IdVeiculo)
                .HasColumnName("ID_VEICULO");


        }

    }
}
