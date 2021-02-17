using CrMallTesteAvaliacao.Interface;
using CrMallTesteAvaliacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace CrMallTesteAvaliacao.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly AppDbContext _context;
        public TaskAwaiter getAwaiter;

        public ClientesRepository()
        {
            getAwaiter = new TaskAwaiter();
        }

        public bool Save()
        {
            try
            {
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Clientes> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        public Clientes GetClienteUnico(int id)
        {
            var clientes =  _context.Clientes.Find(id);

            return clientes;
        }

        public Clientes AddCliente(Clientes clientes)
        {
            _context.Clientes.Add(clientes);

            return clientes;
        }

        public bool VerificarExistenciaCliente(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

        public void EditaCliente(Clientes clientes)
        {
            _context.Entry(clientes).State = EntityState.Modified;
        }

        public void RemoveCliente(Clientes clientes)
        {
            _context.Clientes.Remove(clientes);
        }
    }
}
