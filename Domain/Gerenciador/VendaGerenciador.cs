using Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Gerenciador
{
    public class VendaGerenciador : GerenciadorBase
    {
        public VendaGerenciador()
        {
            _context = new Contex.DContex();
        }

        public void Add(Venda venda)
        {
            try
            {
                if (venda != null)
                    if (venda.Id == 0)
                    {
                        _context.Vendas.Add(venda);
                    }
                    else
                        _context.Vendas.Update(venda);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Venda venda)
        {
            try
            {
                if (venda != null)
                    _context.Vendas.Remove(venda);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Venda RecuperarPorId(int Id)
        {
           return _context.Vendas.Find(Id);
        }

        public IQueryable<Venda> RecuperarVenda()
        {
            return _context.Vendas.Select(p => new Venda()
            {
                Id = p.Id,
                Cliente = p.Cliente,
                IdCliente = p.IdCliente,
                IdVeiculo = p.IdVeiculo,
                Veiculo = p.Veiculo,
            });
        }
    }
}
