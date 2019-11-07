using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Models
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public string Endereco1 { get; set; }
        public int CEP { get; set; }

        public int TempoResidencia { get; set; }

        public IQueryable<EnderecoViewModel> Enderecos { get; set; }

    }
}
