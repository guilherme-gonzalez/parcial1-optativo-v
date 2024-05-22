using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Repository.Data;
using Services.Logica;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace api.personas.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class ClienteController : Controller
    {
        private ClienteService clienteService;
        
        public ClienteController(Repository.Context.ContextAppDB context)
        {
            clienteService = new ClienteService(context);
        }

        // POST
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync(ClienteModel cliente)
        {
            await clienteService.AddAsync(cliente);
            return View();
        }

        // GET
        [HttpGet("Get/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var cliente = await clienteService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // PUT
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ClienteModel cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            await clienteService.UpdateAsync(cliente);
            return NoContent();
        }

        // DELETE
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var cliente = await clienteService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            await clienteService.DeleteAsync(cliente);
            return NoContent();
        }
        
        // LIST
        [HttpGet("List")]
        public async Task<ActionResult> ListAsync()
        {
            try
            {
                var clientes = await clienteService.ListAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
