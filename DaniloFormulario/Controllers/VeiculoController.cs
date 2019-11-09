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
    public class VeiculoController : Controller
    {
        VeiculoGerenciador veiculoGerenciador;

        public VeiculoController()
        {
            veiculoGerenciador = new VeiculoGerenciador();
        }


        public IActionResult Index()
        {

            var veiculo = veiculoGerenciador.RecuperarVeiculo()
                .Select(c => new VeiculoViewModel()
                {
                    NomeVeiculo = c.NomeVeiculo,
                    Valor = c.Valor,

                });

            var model = new VeiculoViewModel { Veiculos = veiculo };
            return View(model);
        }


        [HttpGet]

        public IActionResult Add(int Id)
        {
            var c = veiculoGerenciador.RecuperarPorId(Id);
            var model = new VeiculoViewModel()
            {
                Id = c.Id,
                NomeVeiculo = c.NomeVeiculo,
                Valor = c.Valor,

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Add(VeiculoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Veiculo c = null;

                if (model.Id > 0)
                {
                    c = veiculoGerenciador.RecuperarPorId(model.Id);
                }
                else
                    c = new Veiculo();

                c.Id = model.Id;
                c.NomeVeiculo = model.NomeVeiculo;
                c.Valor = model.Valor;

                veiculoGerenciador.Add(c);
            }

            return RedirectToAction("Index");


        }

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var veiculo = veiculoGerenciador.RecuperarPorId(Id);

            if (veiculo != null)
            {
                veiculoGerenciador.Delete(veiculo);

                var veiculos = veiculoGerenciador.RecuperarVeiculo()
                    .Select(c => new VeiculoViewModel()
                    {
                        Id = c.Id,
                        NomeVeiculo = c.NomeVeiculo,
                        Valor = c.Valor,

                    });

                return PartialView("Veiculos", veiculos);


            }


            return BadRequest("Erro ao deletar Veiculos.");


        }
    }
}
