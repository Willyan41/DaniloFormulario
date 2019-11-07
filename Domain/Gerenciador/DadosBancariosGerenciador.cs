using Domain.Entidade;
using System;
using System.Linq;

namespace Domain.Gerenciador
{
    public class DadosBancariosGerenciador : GerenciadorBase
    {
        public DadosBancariosGerenciador()
        {
            _context = new Contex.DContex();

        }

        public void Add(DadosBancarios dadosBancarios)
        {
            try
            {
                if (dadosBancarios != null)
                {
                    if (dadosBancarios.Id == 0)
                    {
                        _context.dadosBancarios.Add(dadosBancarios);

                    }
                    else
                        _context.dadosBancarios.Update(dadosBancarios);

                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        public void Delete(DadosBancarios dadosBancarios)
        {
            try
            {
                if (dadosBancarios != null)
                {
                    _context.dadosBancarios.Remove(dadosBancarios);
                    _context.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public DadosBancarios RecuperarPorId(int Id)
        {

           return _context.dadosBancarios.Find(Id);

        }

        public IQueryable<DadosBancarios> RecuperarDadosBancarios()
        {

            return _context.dadosBancarios.Select(p => new DadosBancarios
            {
                Id = p.Id,
                CodigoBanco = p.CodigoBanco,
                Agencia = p.Agencia,
                Conta = p.Conta,
                TempoConta = p.TempoConta,
                Obs = p.Obs,
            });

        }

    }
}
