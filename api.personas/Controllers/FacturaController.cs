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
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        public FacturaController(ContextAppDB context)
        {
            _facturaService = new FacturaService(context);
        }

        // POST
        [HttpPost("AddFactura")]
        public async Task<ActionResult> AddAsync([FromBody] FacturaModel factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _facturaService.AddAsync(factura);
            return Ok("Factura added successfully");
        }

        // GET
        [HttpGet("GetFactura/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var factura = await _facturaService.GetAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return Ok(factura);
        }

        // PUT
        [HttpPut("UpdateFactura/{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] FacturaModel factura)
        {
            if (id != factura.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _facturaService.UpdateAsync(factura);
            return NoContent();
        }

        // DELETE
        [HttpDelete("DeleteFactura/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var factura = await _facturaService.GetAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            await _facturaService.DeleteAsync(factura);
            return NoContent();
        }

        // LIST
        [HttpGet("ListFacturas")]
        public async Task<ActionResult> ListAsync()
        {
            try
            {
                var facturas = await _facturaService.ListAsync();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
