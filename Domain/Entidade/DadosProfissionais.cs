using System;

namespace Domain.Entidade
{
    public class DadosProfissionais : EntidadeBase
    {
        public Byte Autonomo { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Double Salario { get; set; }


    }
}
