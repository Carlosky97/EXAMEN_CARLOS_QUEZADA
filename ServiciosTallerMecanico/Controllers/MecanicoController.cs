using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiciosTallerMecanico.Data;
using ServiciosTallerMecanico.Models;

namespace ServiciosTallerMecanico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        private readonly APIMecanicoDbContext _context;

        // Constructor del controlador que recibe el contexto de la base de datos
        public MecanicoController(APIMecanicoDbContext context)
        {
            _context = context;
        }

        // Endpoint HTTP GET para obtener todos los mecánicos
        [HttpGet]
        public async Task<ActionResult<List<Mecanico>>> GetMecanico()
        {
            // Devuelve la lista de mecánicos en formato Ok (200 OK)
            return Ok(await _context.Mecanico.ToListAsync());
        }

        // Endpoint HTTP GET para obtener un mecánico por su ID
        [HttpGet("{id}")]
        public ActionResult<Mecanico> GetCliente(int id)
        {
            // Busca el mecánico por su ID en la base de datos
            var mecanico = _context.Mecanico.Find(id);

            // Si no se encuentra el mecánico, devuelve NotFound (404 Not Found)
            if (mecanico == null)
            {
                return NotFound();
            }

            // Devuelve el mecánico encontrado en formato Ok (200 OK)
            return Ok(mecanico);
        }

        // Endpoint HTTP POST para crear un nuevo mecánico
        [HttpPost]
        public async Task<ActionResult<Mecanico>> Create(Mecanico mecanico)
        {
            // Agrega el nuevo mecánico al contexto de la base de datos
            _context.Add(mecanico);

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Devuelve el nuevo mecánico en formato Ok (200 OK)
            return Ok(mecanico);
        }

        // Endpoint HTTP PUT para actualizar un mecánico por su ID
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Mecanico mecanico)
        {
            // Verifica que el ID proporcionado coincida con el ID del mecánico
            if (id != mecanico.idMecanico)
            {
                // Si no coinciden, devuelve BadRequest (400 Bad Request)
                return BadRequest();
            }

            // Marca el mecánico como modificado en el contexto y guarda los cambios en la base de datos
            _context.Entry(mecanico).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Devuelve el mecánico actualizado en formato Ok (200 OK)
            return Ok(mecanico);
        }

        // Endpoint HTTP DELETE para eliminar un mecánico por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Busca el mecánico por su ID en la base de datos
            var mecanico = await _context.Mecanico.FindAsync(id);

            // Si no se encuentra el mecánico, devuelve NotFound (404 Not Found)
            if (mecanico == null)
            {
                return NotFound("No está correcto el ID del mecánico.");
            }

            // Elimina el mecánico del contexto y guarda los cambios en la base de datos
            _context.Mecanico.Remove(mecanico);
            await _context.SaveChangesAsync();

            // Devuelve Ok (200 OK) indicando que la operación se realizó con éxito
            return Ok();
        }
    }
}

