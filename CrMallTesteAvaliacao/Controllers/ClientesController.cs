using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrMallTesteAvaliacao.Models;
using CrMallTesteAvaliacao.Interface;
using CrMallTesteAvaliacao.Repository;
using System.Net.Http;
using System.Net;

namespace CrMallTesteAvaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private  IClientesRepository clientesRepository;

        public ClientesController()
        {
            clientesRepository = new ClientesRepository();
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IEnumerable<Clientes>> GetClientes()
        {
            return await Task.FromResult(clientesRepository.GetClientes());
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(int id)
        {
            var clientes = await Task.FromResult(clientesRepository.GetClienteUnico(id));

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest();
            }
            clientesRepository.EditaCliente(clientes);

            try
            {
               await Task.FromResult(clientesRepository.Save());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientesRepository.VerificarExistenciaCliente(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
            clientesRepository.AddCliente(clientes);
            var verificaSave = await Task.FromResult(clientesRepository.Save());
            if (verificaSave)
            {
                return CreatedAtAction("GetClientes", new { id = clientes.Id }, clientes);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> DeleteClientes(int id)
        {
            var clientes = await Task.FromResult(clientesRepository.GetClienteUnico(id));
            if (clientes == null)
            {
                return NotFound();
            }
            clientesRepository.RemoveCliente(clientes);

            var verificaSave = await Task.FromResult(clientesRepository.Save());

            if (verificaSave)
            {
                return clientes;
            }
            else
            {
                return NoContent();
            }
        }
    }
}
