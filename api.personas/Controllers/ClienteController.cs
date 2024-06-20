using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Services.Logica;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace api.personas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _clienteRepository;
        private readonly IValidator<ClienteModel> _validator;

        public ClienteController(ICliente clienteRepository, IValidator<ClienteModel> validator)
        {
            _clienteRepository = clienteRepository;
            _validator = validator;
        }

        // POST
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync(ClienteModel cliente)
        {
            ValidationResult result = await _validator.ValidateAsync(cliente);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            await _clienteRepository.AddAsync(cliente);
            return Ok();
        }

        // GET
        [HttpGet("Get/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var cliente = await _clienteRepository.GetAsync(id);
            if (cliente == null || !string.Equals(cliente.estado, "active", StringComparison.OrdinalIgnoreCase))
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

            ValidationResult result = await _validator.ValidateAsync(cliente);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            await _clienteRepository.UpdateAsync(cliente);
            return NoContent();
        }

        // DELETE
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var cliente = await _clienteRepository.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            await _clienteRepository.RemoveAsync(cliente);
            return NoContent();
        }
        
        // LIST
        [HttpGet("List")]
        public async Task<ActionResult> ListAsync()
        {
            try
            {
                var clientes = await _clienteRepository.ListAsync();
                var activeClientes = clientes.Where(cliente => string.Equals(cliente.estado, "active", StringComparison.OrdinalIgnoreCase));
                return Ok(activeClientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
