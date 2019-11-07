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
    public class ContatoController : BaseController
    {

        ContatoGerenciador contatoGerenciador;

        public ContatoController()
        {
            contatoGerenciador = new ContatoGerenciador();
        }


        public IActionResult Index()
        {

            var Contato = contatoGerenciador.RecuperarContato()
                .Select(c => new ContatoViewModel()
                {
                    Celular = c.Celular,
                    Email = c.Email,
                    TelResidencia = c.TelResidencia,

                });

            var model = new ContatoViewModel { Contatos = Contato };
            return View(model);
        }


        [HttpGet]

        public IActionResult Add(int Id)
        {
            var c = contatoGerenciador.RecuperarPorId(Id);
            var model = new ContatoViewModel()
            {
                Id = c.Id,
                Celular = c.Celular,
                Email = c.Email,
                TelResidencia = c.TelResidencia,

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Add(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contato c = null;

                if (model.Id > 0)
                {
                    c = contatoGerenciador.RecuperarPorId(model.Id);
                }
                else
                    c = new Contato();

                c.Id = model.Id;
                c.Celular = model.Celular;
                c.Email = model.Email;
                c.TelResidencia = model.TelResidencia;

                contatoGerenciador.Add(c);
            }

            return RedirectToAction("Index");


        }

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var contato = contatoGerenciador.RecuperarPorId(Id);

            if (contato != null)
            {
                contatoGerenciador.Delete(contato);

                var Contatos = contatoGerenciador.RecuperarContato()
                    .Select(c => new ContatoViewModel()
                    {
                        Id = c.Id,
                        Celular = c.Celular,
                        Email = c.Email,
                        TelResidencia = c.TelResidencia,


                    });

                return PartialView("Contato", Contatos);


            }


            return BadRequest("Erro ao deletar Cliente.");


        }





    }
}