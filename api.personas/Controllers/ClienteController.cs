using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Repository.Data;
using Services.Logica;
using Microsoft.Extensions.Configuration;

namespace api.personas.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class ClienteController : Controller
    {
        private ClienteService clienteService;
        
        public ClienteController(IConfiguration configuracion)
        {
            clienteService = new ClienteService(configuracion.GetConnectionString("postgres"));
        }

        // POST
        [HttpPost("Add")]
        public ActionResult Add(ClienteModel cliente)
        {
            clienteService.Add(cliente);
            return View();
        }

        // GET
        [HttpGet("Get/{id}")]
        public ActionResult Get(int id)
        {
            var cliente = clienteService.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // PUT
        [HttpPut("Update/{id}")]
        public ActionResult Update(int id, ClienteModel cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            clienteService.Update(cliente);
            return NoContent();
        }

        // DELETE
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = clienteService.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }
            clienteService.Delete(cliente);
            return NoContent();
        }
        
        // LIST
        [HttpGet("List")]
        public ActionResult List()
        {
            try
            {
                var clientes = clienteService.list();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}