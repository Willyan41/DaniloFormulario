using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaniloFormulario.Models;
using Domain.Entidade;
using Domain.Gerenciador;
using Microsoft.AspNetCore.Mvc;

namespace DaniloFormulario.Controllers
{
    public class EnderecoController : Controller
    {
        EnderecoGerenciador enderecoGerenciador;

        public EnderecoController()
        {
            enderecoGerenciador = new EnderecoGerenciador();
        }


        public IActionResult Index()
        {

            var enderecos = enderecoGerenciador.RecuperarEndereco()
                .Select(c => new EnderecoViewModel()
                {
                    CEP = c.CEP,
                    Endereco1 = c.Endereco1,
                    TempoResidencia = c.TempoResidencia,
                    

                });

            var model = new EnderecoViewModel { Enderecos = enderecos };
            return View(model);
        }


        [HttpGet]

        public IActionResult Add(int Id)
        {
            var c = enderecoGerenciador.RecuperarPorId(Id);
            var model = new EnderecoViewModel()
            {
                CEP = c.CEP,
                Endereco1 = c.Endereco1,
                TempoResidencia = c.TempoResidencia,

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Add(EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Endereco c = null;

                if (model.Id > 0)
                {
                    c = enderecoGerenciador.RecuperarPorId(model.Id);
                }
                else
                    c = new Endereco();

                c.Id = model.Id;
                c.CEP = model.CEP;
                c.Endereco1 = model.Endereco1;
                c.TempoResidencia = model.TempoResidencia;

                enderecoGerenciador.Add(c);
            }

            return RedirectToAction("Index");


        }

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var endereco = enderecoGerenciador.RecuperarPorId(Id);

            if (endereco != null)
            {
                enderecoGerenciador.Delete(endereco);

                var enderecos = enderecoGerenciador.RecuperarEndereco()
                    .Select(c => new EnderecoViewModel()
                    {
                        Id = c.Id,
                        CEP = c.CEP,
                        Endereco1 = c.Endereco1,
                        TempoResidencia = c.TempoResidencia,


                    });

                return PartialView("Endereços", enderecos);


            }


            return BadRequest("Erro ao deletar Endereços.");


        }
    }
}
