﻿using BEComentarios.Models;
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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comentario = await _context.Comentarios.FindAsync(id);

                if (comentario == null) { return NotFound(); }
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            try
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if (id != comentario.Id )
                {
                    return BadRequest();
                }

                _context.Update(comentario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Comentario actualizado con éxito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comentario = await _context.Comentarios.FindAsync(id);
                if (comentario == null)
                {
                    return NotFound();
                }
                _context.Comentarios.Remove(comentario);
                await _context.SaveChangesAsync();
                return Ok( new { message = "Comentario eliminado con éxito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
