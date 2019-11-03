using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("BS_003_CONTATO");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID_CONTATO");

            builder.Property(p => p.Email)
                .HasColumnName("EMAIL");

            builder.Property(p => p.Celular)
                .HasColumnName("CELULAR");

            builder.Property(p => p.TelResidencia)
                .HasColumnName("TEL_RESIDENCIA");


        }



    }
}
