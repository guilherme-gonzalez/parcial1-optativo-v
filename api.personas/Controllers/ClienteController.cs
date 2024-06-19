using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Repository.Data;
using Services.Logica;
using Repository.Context;
using System.Threading.Tasks;

namespace api.personas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ContextAppDB context)
        {
            _clienteService = new ClienteService(context);
        }

        // POST
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] ClienteModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clienteService.AddAsync(cliente);
            return Ok("Cliente added successfully");
        }

        // GET
        [HttpGet("Get/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // PUT
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] ClienteModel cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clienteService.UpdateAsync(cliente);
            return NoContent();
        }

        // DELETE
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteService.DeleteAsync(cliente);
            return NoContent();
        }

        // LIST
        [HttpGet("List")]
        public async Task<ActionResult> ListAsync()
        {
            try
            {
                var clientes = await _clienteService.ListAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
