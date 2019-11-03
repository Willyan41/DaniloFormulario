using System;

namespace Domain.Entidade
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public Byte CNH { get; set; }
        public string LocalNascimento { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public int TempoResidencia { get; set; }


    }
}
