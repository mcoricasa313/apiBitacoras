using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Usmp.Fia.NetCoreWebAplication.AppBitacoras.Data;
using Usmp.Fia.NetCoreWebAplication.AppBitacoras.Entidades;
using BitacorasContexto = Usmp.Fia.NetCoreWebAplication.AppBitacoras.Data.BitacorasContexto;

namespace Usmp.Fia.NetCoreWebAplication.AppBitacoras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestresController : ControllerBase
    {
        private readonly BitacorasContexto _context;

        public SemestresController(BitacorasContexto context)
        {
            _context = context;
        }

        // GET: api/Semestres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semestres>>> GetSemestres()
        {
            return await _context.Semestres.ToListAsync();
        }

        // GET: api/Semestres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semestres>> GetSemestres(int id)
        {
            var semestres = await _context.Semestres.FindAsync(id);

            if (semestres == null)
            {
                return NotFound();
            }

            return semestres;
        }

        // PUT: api/Semestres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemestres(int id, Semestres semestres)
        {
            if (id != semestres.idsemestre)
            {
                return BadRequest();
            }

            _context.Entry(semestres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemestresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Semestres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Semestres>> PostSemestres(Semestres semestres)
        {
            _context.Semestres.Add(semestres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSemestres", new { id = semestres.idsemestre }, semestres);
        }

        // DELETE: api/Semestres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Semestres>> DeleteSemestres(int id)
        {
            var semestres = await _context.Semestres.FindAsync(id);
            if (semestres == null)
            {
                return NotFound();
            }

            _context.Semestres.Remove(semestres);
            await _context.SaveChangesAsync();

            return semestres;
        }

        private bool SemestresExists(int id)
        {
            return _context.Semestres.Any(e => e.idsemestre == id);
        }
    }
}
