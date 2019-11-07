using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Models
{
    public class VeiculoViewModel
    {
        public string NomeVeiculo { get; set; }
        public double Valor { get; set; }

        public IQueryable<VeiculoViewModel> Veiculos { get; set; }


    }
}
