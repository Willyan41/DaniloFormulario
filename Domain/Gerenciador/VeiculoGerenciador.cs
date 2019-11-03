using Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Gerenciador
{
    public class VeiculoGerenciador : GerenciadorBase
    {
        public VeiculoGerenciador()
        {
            _context = new Contex.DContex();
        }

        public void Add(Veiculo veiculo)
        {
            try
            {
                if (veiculo != null)
                {
                    if (veiculo.Id == 0)
                    {
                        _context.Veiculos.Add(veiculo);
                    }
                    else
                        _context.Veiculos.Update(veiculo);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Veiculo veiculo)
        {
            try
            {
                if (veiculo != null)
                {
                    _context.Veiculos.Remove(veiculo);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RecuperarPorId(int Id)
        {
            _context.Veiculos.Find(Id);
        }

        public IQueryable<Veiculo> RecuperarVeiculo()
        {
            return _context.Veiculos.Select(p => new Veiculo()
            {
                Id = p.Id,
                NomeVeiculo = p.NomeVeiculo,
                Valor = p.Valor,
            });
        }
    }
}
