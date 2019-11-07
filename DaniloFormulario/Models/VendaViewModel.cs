using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Models
{
    public class VendaViewModel
    { 
        public int Id { get; set; }
        public int IdCliente { get; set; }
        //public Cliente Cliente { get; set; }

        public int IdVeiculo { get; set; }
        //public Veiculo Veiculo { get; set; }

        public IQueryable<VendaViewModel> Vendas { get; set; }
    }
}
