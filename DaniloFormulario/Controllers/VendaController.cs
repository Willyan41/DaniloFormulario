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
    public class VendaController : Controller
    {
        VendaGerenciador vendaGerenciador;

        public VendaController()
        {
            vendaGerenciador = new VendaGerenciador();
        }


        public IActionResult Index()
        {

            var venda = vendaGerenciador.RecuperarVenda()
                .Select(c => new VendaViewModel()
                {
                    IdCliente = c.IdCliente,
                    IdVeiculo = c.IdVeiculo,
                   

                });

            var model = new VendaViewModel { Vendas = venda };
            return View(model);
        }


        [HttpGet]

        public IActionResult Add(int Id)
        {
            var c = vendaGerenciador.RecuperarPorId(Id);
            var model = new VendaViewModel()
            {
                Id = c.Id,
                IdCliente = c.IdCliente,
                IdVeiculo = c.IdVeiculo,


            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Add(VendaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Venda c = null;

                if (model.Id > 0)
                {
                    c = vendaGerenciador.RecuperarPorId(model.Id);
                }
                else
                    c = new Venda();

                c.Id = model.Id;
                c.IdCliente = model.IdCliente;
                c.IdVeiculo = model.IdVeiculo;


                vendaGerenciador.Add(c);
            }

            return RedirectToAction("Index");


        }

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var venda = vendaGerenciador.RecuperarPorId(Id);

            if (venda != null)
            {
                vendaGerenciador.Delete(venda);

                var vendas = vendaGerenciador.RecuperarVenda()
                    .Select(c => new VendaViewModel()
                    {
                        Id = c.Id,
                        IdCliente = c.IdCliente,
                        IdVeiculo = c.IdVeiculo,


                    });

                return PartialView("Vendas", vendas);


            }


            return BadRequest("Erro ao deletar Vendas.");


        }
    }
}
