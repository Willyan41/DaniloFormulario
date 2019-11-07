using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Models
{
    public class DadosProfissionaisViewModel
    {
        public int Id { get; set; }
        public Byte Autonomo { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Double Salario { get; set; }

        public IQueryable<DadosProfissionaisViewModel> DadosProfissionais { get; set; }
    }
}
