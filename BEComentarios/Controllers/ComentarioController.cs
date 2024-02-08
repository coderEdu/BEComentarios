using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEComentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComentarioController(ApplicationDbContext context) 
        {
            _context = context; 
        }

        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listComentarios = await _context.Comentarios.ToListAsync();
                return Ok(listComentarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]                                   
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
