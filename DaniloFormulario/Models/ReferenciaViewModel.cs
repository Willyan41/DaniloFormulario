using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Models
{
    public class ReferenciaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Telefone { get; set; }

        public IQueryable<ReferenciaViewModel> Referencias { get; set; }
    }
}
