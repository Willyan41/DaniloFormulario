using Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Gerenciador
{
    public class ContatoGerenciador : GerenciadorBase
    {
        public ContatoGerenciador()
        {
            _context = new Contex.DContex();
        }

        public void Add(Contato Contato)
        {
            try
            {
                if (Contato != null)
                {
                    if (Contato.Id == 0)
                    {
                        _context.Contatos.Add(Contato);
                    }
                    else
                        _context.Contatos.Update(Contato);

                    _context.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public void Delete(Contato Contato)
        {
            try
            {
                if (Contato != null)
                {
                    _context.Contatos.Remove(Contato);
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
            _context.Contatos.Find(Id);

        }


        public IQueryable<Contato> RecuperarContato()
        {
            return _context.Contatos.Select(p => new Contato
            {
                Id = p.Id,
                Celular = p.Celular,
                TelResidencia = p.TelResidencia,
                Email = p.Email,
            });

        }



    }
}
