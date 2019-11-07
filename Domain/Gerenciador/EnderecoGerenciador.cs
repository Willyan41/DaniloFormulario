using Domain.Entidade;
using System;
using System.Linq;

namespace Domain.Gerenciador
{
    public class EnderecoGerenciador : GerenciadorBase
    {
        public EnderecoGerenciador()
        {
            _context = new Contex.DContex();
        }

        public void Add(Endereco endereco)
        {
            try
            {
                if (endereco != null)
                {
                    if (endereco.Id == 0)
                    {
                        _context.Enderecos.Add(endereco);
                    }
                    else
                        _context.Enderecos.Update(endereco);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Delete(Endereco endereco)
        {
            try
            {
                if (endereco != null)
                {
                    _context.Enderecos.Remove(endereco);
                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public Endereco RecuperarPorId(int Id)
        {

           return _context.Enderecos.Find(Id);

        }

        public IQueryable<Endereco> RecuperarEndereco()
        {
            return _context.Enderecos.Select(p => new Endereco()
            {
                Id = p.Id,
                CEP = p.CEP,
                Endereco1 = p.Endereco1,
                TempoResidencia = p.TempoResidencia,
            });
        }

    }
}
