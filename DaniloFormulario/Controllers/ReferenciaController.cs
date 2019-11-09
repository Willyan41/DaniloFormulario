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
    public class ReferenciaController : Controller
    {
        ReferenciaGerenciador referenciaGerenciador;

        public ReferenciaController()
        {
            referenciaGerenciador = new ReferenciaGerenciador();
        }


        public IActionResult Index()
        {

            var referencia = referenciaGerenciador.RecuperarReferencia()
                .Select(c => new ReferenciaViewModel()
                {
                    Nome = c.Nome,
                    Telefone = c.Telefone,

                });

            var model = new ReferenciaViewModel { Referencias = referencia };
            return View(model);
        }


        [HttpGet]

        public IActionResult Add(int Id)
        {
            var c = referenciaGerenciador.RecuperarPorId(Id);
            var model = new ReferenciaViewModel()
            {
                Id = c.Id,
                Nome = c.Nome,
                Telefone = c.Telefone,

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Add(ReferenciaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Referencia c = null;

                if (model.Id > 0)
                {
                    c = referenciaGerenciador.RecuperarPorId(model.Id);
                }
                else
                    c = new Referencia();

                c.Id = model.Id;
                c.Nome = model.Nome;
                c.Telefone = model.Telefone;


                referenciaGerenciador.Add(c);
            }

            return RedirectToAction("Index");


        }

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var referencia = referenciaGerenciador.RecuperarPorId(Id);

            if (referencia != null)
            {
                referenciaGerenciador.Delete(referencia);

                var referencias = referenciaGerenciador.RecuperarReferencia()
                    .Select(c => new ReferenciaViewModel()
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        Telefone = c.Telefone,

                    });

                return PartialView("Referencia", referencias);


            }


            return BadRequest("Erro ao deletar Referencia.");


        }
    }
}
