using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Usmp.Fia.NetCoreWebAplication.AppBitacoras.Data;
using Usmp.Fia.NetCoreWebAplication.AppBitacoras.Entidades;

namespace Usmp.Fia.NetCoreWebAplication.AppBitacoras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrantesPorGruposController : ControllerBase
    {
        private readonly BitacorasContexto _context;

        public IntegrantesPorGruposController(BitacorasContexto context)
        {
            _context = context;
        }

        // GET: api/IntegrantesPorGrupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntegrantesPorGrupo>>> GetIntegrantesPorGrupo()
        {
            return await _context.IntegrantesPorGrupo.ToListAsync();
        }

        // GET: api/IntegrantesPorGrupos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IntegrantesPorGrupo>> GetIntegrantesPorGrupo(int id)
        {
            var integrantesPorGrupo = await _context.IntegrantesPorGrupo.FindAsync(id);

            if (integrantesPorGrupo == null)
            {
                return NotFound();
            }

            return integrantesPorGrupo;
        }

        // PUT: api/IntegrantesPorGrupos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntegrantesPorGrupo(int id, IntegrantesPorGrupo integrantesPorGrupo)
        {
            if (id != integrantesPorGrupo.IdIntegrantesPorGrupos)
            {
                return BadRequest();
            }

            _context.Entry(integrantesPorGrupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegrantesPorGrupoExists(id))
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

        // POST: api/IntegrantesPorGrupos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IntegrantesPorGrupo>> PostIntegrantesPorGrupo(IntegrantesPorGrupo integrantesPorGrupo)
        {
            _context.IntegrantesPorGrupo.Add(integrantesPorGrupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntegrantesPorGrupo", new { id = integrantesPorGrupo.IdIntegrantesPorGrupos }, integrantesPorGrupo);
        }

        // DELETE: api/IntegrantesPorGrupos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IntegrantesPorGrupo>> DeleteIntegrantesPorGrupo(int id)
        {
            var integrantesPorGrupo = await _context.IntegrantesPorGrupo.FindAsync(id);
            if (integrantesPorGrupo == null)
            {
                return NotFound();
            }

            _context.IntegrantesPorGrupo.Remove(integrantesPorGrupo);
            await _context.SaveChangesAsync();

            return integrantesPorGrupo;
        }

        private bool IntegrantesPorGrupoExists(int id)
        {
            return _context.IntegrantesPorGrupo.Any(e => e.IdIntegrantesPorGrupos == id);
        }
    }
}
