using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class DadosProfissionaisMap : IEntityTypeConfiguration<DadosProfissionais>
    {
        public void Configure(EntityTypeBuilder<DadosProfissionais> builder)
        {
            builder.ToTable("BS_004_DADOS_PROFISSIONAIS");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID_DADOS_PROFISSIONAIS");

            builder.Property(p => p.Autonomo)
                .HasColumnName("AUTONOMO");

            builder.Property(p => p.Empresa)
                .HasColumnName("EMPRESA");

            builder.Property(p => p.Cargo)
                .HasColumnName("CARGO");

            builder.Property(p => p.DataAdmissao)
                .HasColumnName("DATA_ADMISSAO");

            builder.Property(p => p.Salario)
                .HasColumnName("SALARIO");




        }


    }
}
