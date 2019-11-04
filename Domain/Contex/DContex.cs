using Domain.Entidade;
using Domain.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace Domain.Contex
{
    public class DContex : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<DadosBancarios> dadosBancarios { get; set; }

        public DbSet<DadosProfissionais> dadosProfissionais { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Referencia> Referencias { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Venda> Vendas { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new DadosBancariosMap());
            modelBuilder.ApplyConfiguration(new DadosProfissionaisMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ReferenciaMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BOMBINHA;Initial Catalog=DANILO_VEICULOS;Integrated Security=True");
        }


    }
}
