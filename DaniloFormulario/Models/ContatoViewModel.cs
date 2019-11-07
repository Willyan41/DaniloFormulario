using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Models
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public int Celular { get; set; }

        public int TelResidencia { get; set; }

        public IQueryable<ContatoViewModel> Contatos { get; set; }
    }
}
