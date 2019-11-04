using DaniloFormulario.Models;
using Domain.Entidade;
using Domain.Gerenciador;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloFormulario.Controllers
{
    public class ClienteController : BaseController
    {
        ClienteGerenciador clienteGerenciador;
        //private IHostingEnvironment _env;

        public ClienteController()
        {
            clienteGerenciador = new ClienteGerenciador();

        }

        public IActionResult Index()
        {
            var Clientes = clienteGerenciador.RecuperarCliente()
                .Select(c => new ClienteViewModel()
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    CPF = c.CPF,
                    RG = c.RG,
                    DataNascimento = c.DataNascimento,
                    CNH = c.CNH,
                    LocalNascimento = c.LocalNascimento,
                    NomePai = c.NomePai,
                    NomeMae = c.NomeMae,
                    TempoResidencia = c.TempoResidencia,
                });
            var model = new ClienteViewModel { Clientes = Clientes };
            return View(model);

        }

        [HttpGet]

        public IActionResult Add(int Id)
        {
            var c = clienteGerenciador.RecuperarPorID(Id);
            var model = new ClienteViewModel()
            {
                Id = c.Id,
                Nome = c.Nome,
                CPF = c.CPF,
                RG = c.RG,
                DataNascimento = c.DataNascimento,
                CNH = c.CNH,
                LocalNascimento = c.LocalNascimento,
                NomePai = c.NomePai,
                NomeMae = c.NomeMae,
                TempoResidencia = c.TempoResidencia,

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Add(ClienteViewModel model)
        {

            if (ModelState.IsValid)
            {
                Cliente c = null;

                if (model.Id > 0)
                    c = clienteGerenciador.RecuperarPorID(model.Id);
                else
                    c = new Cliente();

                c.Id = model.Id;
                c.Nome = model.Nome;
                c.CPF = model.CPF;
                c.RG = model.RG;
                c.DataNascimento = model.DataNascimento;
                c.CNH = model.CNH;
                c.LocalNascimento = model.LocalNascimento;
                c.NomePai = model.NomePai;
                c.NomeMae = model.NomeMae;
                c.TempoResidencia = model.TempoResidencia;

                clienteGerenciador.Add(c);

            }

            return RedirectToAction("Index");

        }

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var cliente = clienteGerenciador.RecuperarPorID(Id);

            if (cliente != null)
            {
                clienteGerenciador.Delete(cliente);

                var clientes = clienteGerenciador.RecuperarCliente()
                    .Select(c => new ClienteViewModel()
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        CPF = c.CPF,
                        RG = c.RG,
                        DataNascimento = c.DataNascimento,
                        CNH = c.CNH,
                        LocalNascimento = c.LocalNascimento,
                        NomePai = c.NomePai,
                        NomeMae = c.NomeMae,
                        TempoResidencia = c.TempoResidencia,

                    });
                return PartialView("Cliente", clientes);

            }

            return BadRequest("Erro ao deletar Cliente.");




        }





    }
}
