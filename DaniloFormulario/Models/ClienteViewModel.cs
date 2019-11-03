using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public Byte CNH { get; set; }
        public string LocalNascimento { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public int TempoResidencia { get; set; }

        public IQueryable<ClienteViewModel> Clientes { get; set; }
    }
}
