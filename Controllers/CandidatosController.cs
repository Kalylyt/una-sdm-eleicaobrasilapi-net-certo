using Microsoft.AspNetCore.Mvc;
using EleicaoBrasilApi.Data;
using EleicaoBrasilApi.Models;

namespace EleicaoBrasilApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidatosController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Candidatos.ToList());
        }

        // GET por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var candidato = _context.Candidatos.Find(id);
            if (candidato == null) return NotFound();
            return Ok(candidato);
        }

        // POST
        [HttpPost]
        public IActionResult Post(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = candidato.Id }, candidato);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, Candidato candidato)
        {
            var existente = _context.Candidatos.Find(id);
            if (existente == null) return NotFound();

            existente.Nome = candidato.Nome;
            existente.Partido = candidato.Partido;
            existente.Idade = candidato.Idade;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var candidato = _context.Candidatos.Find(id);
            if (candidato == null) return NotFound();

            _context.Candidatos.Remove(candidato);
            _context.SaveChanges();

            return NoContent();
        }
    }
}