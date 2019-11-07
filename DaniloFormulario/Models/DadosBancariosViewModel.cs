using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Models
{
    public class DadosBancariosViewModel
    {
        public int CodigoBanco { get; set; }
        public string Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public int TempoConta { get; set; }
        public string Obs { get; set; }

    }
}
