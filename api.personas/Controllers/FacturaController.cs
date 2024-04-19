using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Repository.Data;
using Services.Logica;
using Microsoft.Extensions.Configuration;

namespace api.personas.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class FacturaController : Controller
    {
        private FacturaService facturaService;

        public FacturaController(IConfiguration configuracion)
        {
            facturaService = new FacturaService(configuracion.GetConnectionString("postgres"));
        }

        // POST
        [HttpPost("AddFactura")]
        public ActionResult Add(FacturaModel factura)
        {
            facturaService.Add(factura);
            return View();
        }

        // GET
        [HttpGet("GetFactura/{id}")]
        public ActionResult Get(int id)
        {
            var factura = facturaService.Get(id);
            if (factura == null)
            {
                return NotFound();
            }
            return Ok(factura);
        }

        // PUT
        [HttpPut("UpdateFactura/{id}")]
        public ActionResult Update(int id, FacturaModel factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }
            facturaService.Update(factura);
            return NoContent();
        }

        // DELETE
        [HttpDelete("DeleteFactura/{id}")]
        public ActionResult Delete(int id)
        {
            var factura = facturaService.Get(id);
            if (factura == null)
            {
                return NotFound();
            }
            facturaService.Delete(factura);
            return NoContent();
        }
        // List All Facturas
        [HttpGet("ListFacturas")]
        public ActionResult List()
        {
            try
            {
                var facturas = facturaService.list();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}