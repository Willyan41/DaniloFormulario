namespace Domain.Entidade
{
    public class Venda : EntidadeBase
    {
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public int IdVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }


    }
}
