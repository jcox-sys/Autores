using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Libro>>> Get()
        {
            return await context.Libros.Include(x => x.Autor).ToListAsync();
        }

    
        [HttpGet("primero")]
        public async Task<ActionResult<Libro>> GetPr()
        {
            return await context.Libros.FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> Post(Libro libro)
        {
            var existeAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);

            if (!existeAutor)
            {
                return BadRequest($"No existe el autor de Id:{libro.AutorId}");
            }

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
