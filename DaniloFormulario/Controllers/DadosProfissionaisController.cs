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
    public class DadosProfissionaisController : Controller
    {
        DadosProfissionaisGerenciador dadosProfissionaisGerenciador;

        public DadosProfissionaisController()
        {
            dadosProfissionaisGerenciador = new DadosProfissionaisGerenciador();
        }


        public IActionResult Index()
        {

            var dadosProfissionais = dadosProfissionaisGerenciador.RecuperarDadosProfissionais()
                .Select(c => new DadosProfissionaisViewModel()
                {
                    Autonomo = c.Autonomo,
                    Empresa = c.Empresa,
                    Cargo = c.Cargo,
                    DataAdmissao = c.DataAdmissao,
                    Salario = c.Salario,

                });

            var model = new DadosProfissionaisViewModel { DadosProfissionais = dadosProfissionais };
            return View(model);
        }


        [HttpGet]

        public IActionResult Add(int Id)
        {
            var c = dadosProfissionaisGerenciador.RecuperarPorId(Id);
            var model = new DadosProfissionaisViewModel()
            {
                Id = c.Id,
                Autonomo = c.Autonomo,
                Empresa = c.Empresa,
                Cargo = c.Cargo,
                DataAdmissao = c.DataAdmissao,
                Salario = c.Salario,

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Add(DadosProfissionaisViewModel model)
        {
            if (ModelState.IsValid)
            {
                DadosProfissionais c = null;

                if (model.Id > 0)
                {
                    c = dadosProfissionaisGerenciador.RecuperarPorId(model.Id);
                }
                else
                    c = new DadosProfissionais();

                c.Id = model.Id;
                c.Autonomo = model.Autonomo;
                c.Empresa = model.Empresa;
                c.Cargo = model.Cargo;
                c.DataAdmissao = model.DataAdmissao;
                c.Salario = model.Salario;

                dadosProfissionaisGerenciador.Add(c);
            }

            return RedirectToAction("Index");


        }

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var dadosProfissionais = dadosProfissionaisGerenciador.RecuperarPorId(Id);

            if (dadosProfissionais != null)
            {
                dadosProfissionaisGerenciador.Delete(dadosProfissionais);

                var dadosProfissionai = dadosProfissionaisGerenciador.RecuperarDadosProfissionais()
                    .Select(c => new DadosProfissionaisViewModel()
                    {
                        Id = c.Id,
                        Autonomo = c.Autonomo,
                        Empresa = c.Empresa,
                        Cargo = c.Cargo,
                        DataAdmissao = c.DataAdmissao,
                        Salario = c.Salario,


                    });

                return PartialView("DadosProfissionais", dadosProfissionai);


            }


            return BadRequest("Erro ao deletar DadosProfissionais.");


        }
    }
}