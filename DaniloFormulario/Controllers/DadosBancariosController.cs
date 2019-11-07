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
    public class DadosBancariosController : Controller
    {
        DadosBancariosGerenciador dadosBancariosGerenciador;

        public DadosBancariosController()
        {
            dadosBancariosGerenciador = new DadosBancariosGerenciador();
        }


        public IActionResult Index()
        {

            var dadosBancarios = dadosBancariosGerenciador.RecuperarDadosBancarios()
                .Select(c => new DadosBancariosViewModel()
                {
                    Agencia = c.Agencia,
                    Banco = c.Banco,
                    CodigoBanco = c.CodigoBanco,
                    Conta = c.Conta,
                    Obs = c.Obs,
                    TempoConta = c.TempoConta,

                });

            var model = new DadosBancariosViewModel { DadosBancarios = dadosBancarios };
            return View(model);
        }


        [HttpGet]

        public IActionResult Add(int Id)
        {
            var c = dadosBancariosGerenciador.RecuperarPorId(Id);
            var model = new DadosBancariosViewModel()
            {
                Id = c.Id,
                Agencia = c.Agencia,
                Banco = c.Banco,
                CodigoBanco = c.CodigoBanco,
                Conta = c.Conta,
                Obs = c.Obs,
                TempoConta = c.TempoConta,

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Add(DadosBancariosViewModel model)
        {
            if (ModelState.IsValid)
            {
                DadosBancarios c = null;

                if (model.Id > 0)
                {
                    c = dadosBancariosGerenciador.RecuperarPorId(model.Id);
                }
                else
                    c = new DadosBancarios();

                c.Id = model.Id;
                c.Agencia = model.Agencia;
                c.Banco = model.Banco;
                c.CodigoBanco = model.CodigoBanco;
                c.Conta = model.Conta;
                c.Obs = model.Obs;
                c.TempoConta = model.TempoConta;

                dadosBancariosGerenciador.Add(c);
            }

            return RedirectToAction("Index");


        }

        [HttpGet]

        public IActionResult Delete(int Id)
        {
            var dadosBancarios = dadosBancariosGerenciador.RecuperarPorId(Id);

            if (dadosBancarios != null)
            {
                dadosBancariosGerenciador.Delete(dadosBancarios);

                var dadosBancario = dadosBancariosGerenciador.RecuperarDadosBancarios()
                    .Select(c => new DadosBancariosViewModel()
                    {
                        Id = c.Id,
                        Agencia = c.Agencia,
                        Banco = c.Banco,
                        CodigoBanco = c.CodigoBanco,
                        Conta = c.Conta,
                        Obs = c.Obs,
                        TempoConta = c.TempoConta,


                    });

                return PartialView("DadosBancarios", dadosBancario);


            }


            return BadRequest("Erro ao deletar Dados_Bancarios.");


        }




    }
}