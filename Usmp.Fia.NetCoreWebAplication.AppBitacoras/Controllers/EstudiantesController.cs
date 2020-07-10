﻿using System;
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
    public class EstudiantesController : ControllerBase
    {
        private readonly BitacorasContexto _context;

        public EstudiantesController(BitacorasContexto context)
        {
            _context = context;
        }

        [Route("GetEstudiantesSinAsingar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiantes>>> GetEstudiantesSinAsingar()
        {
            var lista = _context.IntegrantesPorGrupo.ToList();
            var listaidestudiantes = lista.Select(f => f.idestudiante).ToList();
            var x = _context.Estudiantes.Where(c => !listaidestudiantes.Contains(c.idestudiante)).ToList();
            return await _context.Estudiantes.Where(c=> !listaidestudiantes.Contains(c.idestudiante)).ToListAsync();        
        }

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiantes>>> GetEstudiantes()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiantes>> GetEstudiantes(int id)
        {
            var estudiantes = await _context.Estudiantes.FindAsync(id);

            if (estudiantes == null)
            {
                return NotFound();
            }

            return estudiantes;
        }

        // PUT: api/Estudiantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiantes(int id, Estudiantes estudiantes)
        {
            if (id != estudiantes.idestudiante)
            {
                return BadRequest();
            }

            _context.Entry(estudiantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudiantesExists(id))
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

        // POST: api/Estudiantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Estudiantes>> PostEstudiantes(Estudiantes estudiantes)
        {
            _context.Estudiantes.Add(estudiantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiantes", new { id = estudiantes.idestudiante }, estudiantes);
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estudiantes>> DeleteEstudiantes(int id)
        {
            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiantes);
            await _context.SaveChangesAsync();

            return estudiantes;
        }

        private bool EstudiantesExists(int id)
        {
            return _context.Estudiantes.Any(e => e.idestudiante == id);
        }
    }
}
