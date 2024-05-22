using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Repository.Data;
using Services.Logica;
using System.Threading.Tasks;

namespace api.personas.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class FacturaController : Controller
    {
        private FacturaService facturaService;
        
        public FacturaController(Repository.Context.ContextAppDB context)
        {
            facturaService = new FacturaService(context);
        }

        // POST
        [HttpPost("AddFactura")]
        public async Task<ActionResult> AddAsync(FacturaModel factura)
        {
            await facturaService.AddAsync(factura);
            return View();
        }

        // GET
        [HttpGet("GetFactura/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var factura = await facturaService.GetAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return Ok(factura);
        }

        // PUT
        [HttpPut("UpdateFactura/{id}")]
        public async Task<ActionResult> UpdateAsync(int id, FacturaModel factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }
            await facturaService.UpdateAsync(factura);
            return NoContent();
        }

        // DELETE
        [HttpDelete("DeleteFactura/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var factura = await facturaService.GetAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            await facturaService.DeleteAsync(factura);
            return NoContent();
        }
        
        // LIST
        [HttpGet("ListFacturas")]
        public async Task<ActionResult> ListAsync()
        {
            try
            {
                var facturas = await facturaService.ListAsync();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
