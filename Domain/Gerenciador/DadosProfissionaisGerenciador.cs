using Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Gerenciador
{
    public class DadosProfissionaisGerenciador : GerenciadorBase
    {
        public DadosProfissionaisGerenciador()
        {
            _context = new Contex.DContex();

        }

        public void Add(DadosProfissionais dadosProfissionais)
        {
            try
            {
                if (dadosProfissionais != null)
                {
                    if (dadosProfissionais.Id == 0)
                    {
                        _context.dadosProfissionais.Add(dadosProfissionais);

                    }
                    else
                        _context.dadosProfissionais.Update(dadosProfissionais);

                    _context.SaveChanges();
                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(DadosProfissionais dadosProfissionais)
        {
            try
            {
                if (dadosProfissionais != null)
                    _context.dadosProfissionais.Remove(dadosProfissionais);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public DadosProfissionais RecuperarPorId(int Id)
        {
           return _context.dadosProfissionais.Find(Id);
        }

        public IQueryable<DadosProfissionais> RecuperarDadosProfissionais()
        {
            return _context.dadosProfissionais.Select(p => new DadosProfissionais
            {
                Id = p.Id,
                Autonomo = p.Autonomo,
                Cargo = p.Cargo,
                DataAdmissao = p.DataAdmissao,
                Empresa = p.Empresa,
                Salario = p.Salario,
            });

        }

    }
}
