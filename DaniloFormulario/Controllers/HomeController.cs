using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DaniloFormulario.Models;
using Domain.Gerenciador;

namespace DaniloFormulario.Controllers
{
    public class HomeController : BaseController
    {
        ClienteGerenciador clienteGerenciador;

        public HomeController()
        {
            clienteGerenciador = new ClienteGerenciador();
        }

        public IActionResult Index()
        {
            return View(clienteGerenciador.RecuperarCliente());
            
        }

    }
}
