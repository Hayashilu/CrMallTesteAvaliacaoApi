using CrMallTesteAvaliacao.Models;
using CrMallTesteAvaliacao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrMallTesteAvaliacao.Interface
{
    interface IClientesRepository 
    {

        bool Save();
        IEnumerable<Clientes> GetClientes();
        Clientes GetClienteUnico(int id);
        Clientes AddCliente(Clientes clientes);
        bool VerificarExistenciaCliente(int id);
        void EditaCliente(Clientes clientes);
        public void RemoveCliente(Clientes clientes);

    }
}
