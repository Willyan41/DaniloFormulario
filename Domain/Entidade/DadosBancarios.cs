namespace Domain.Entidade
{
    public class DadosBancarios : EntidadeBase
    {
        public int CodigoBanco { get; set; }
        public string Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public int TempoConta { get; set; }
        public string Obs { get; set; }


    }
}
