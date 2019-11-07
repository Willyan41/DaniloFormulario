using Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Gerenciador
{
    public class ReferenciaGerenciador : GerenciadorBase
    {
        public ReferenciaGerenciador()
        {
            _context = new Contex.DContex();
        }

        public void Add(Referencia referencia)
        {
            try
            {
                if (referencia != null)
                {
                    if (referencia.Id == 0)
                    {
                        _context.Referencias.Add(referencia);
                    }
                    else
                        _context.Referencias.Update(referencia);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Referencia referencia)
        {
            try
            {
                if (referencia != null)
                {
                    _context.Referencias.Remove(referencia);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Referencia RecuperarPorId(int Id)
        {
           return _context.Referencias.Find(Id);
        }

        public IQueryable<Referencia> RecuperarReferencia()
        {
            return _context.Referencias.Select(p => new Referencia()
            {
                Id = p.Id,
                Nome = p.Nome,
                Telefone = p.Telefone,
            });
        }
    }
}
