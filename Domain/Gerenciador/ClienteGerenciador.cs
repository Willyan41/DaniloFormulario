using Domain.Entidade;
using System;
using System.Linq;

namespace Domain.Gerenciador
{
    public class ClienteGerenciador : GerenciadorBase
    {
        public ClienteGerenciador()
        {
            _context = new Contex.DContex();
        }

        public void Delete(Cliente Cliente)
        {
            try
            {
                if (Cliente != null)
                {
                    _context.Clientes.Remove(Cliente);
                    _context.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public void Add(Cliente Cliente)
        {
            try
            {
                if (Cliente != null)
                {
                    if (Cliente.Id == 0)
                    {
                        _context.Clientes.Add(Cliente);

                    }
                    else
                        _context.Update(Cliente);

                    _context.SaveChanges();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }

        public IQueryable<Cliente> RecuperarCliente()
        {
            return _context.Clientes.Select(p => new Cliente
            {
                Id = p.Id,
                Nome = p.Nome,
                CPF = p.CPF,
                RG = p.RG,
                DataNascimento = p.DataNascimento,
                CNH = p.CNH,
                LocalNascimento = p.LocalNascimento,
                NomePai = p.NomePai,
                NomeMae = p.NomeMae,
                TempoResidencia = p.TempoResidencia,

            });


        }

        public Cliente RecuperarPorID(int Id)
        {
            return _context.Clientes.Find(Id);

        }






    }
}
