﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidInfoWebService.DataAccess;
using CovidInfoWebService.Models;
using CovidInfoWebService.Utils;

namespace CovidInfoWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteCasoController : ControllerBase
    {
        private readonly InfoCovidDbContext _context;

        public ReporteCasoController(InfoCovidDbContext context)
        {
            _context = context;
        }

        // GET: api/ReporteCaso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CasoCovid>>> GetCasosCovid([FromQuery] string pais, 
            [FromQuery] string departamento, 
            [FromQuery] string municipio,
            [FromQuery] byte? edad,
            [FromQuery] char? sexo,
            [FromQuery] DateTime? fecha)
        {

            var casos = _context.CasosCovid.AsQueryable()
                .FiltrarPorPais(pais)
                .FiltrarPorDepartamento(departamento)
                .FiltrarPorMunicipio(municipio)
                .FiltrarPorEdad(edad)
                .FiltrarPorSexo(sexo)
                .FiltrarPorFecha(fecha).AsEnumerable();
            

            return Ok(new
            { 
                total = casos.Count(),
                registros = casos,
                filtro = new { pais, departamento, municipio, edad, sexo, fecha },
            });
        }

        // GET: api/ReporteCaso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CasoCovid>> GetCasoCovid(int id)
        {
            var casoCovid = await _context.CasosCovid.FindAsync(id);

            if (casoCovid == null)
            {
                return NotFound();
            }

            return casoCovid;
        }

        // PUT: api/ReporteCaso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCasoCovid(int id, CasoCovid casoCovid)
        //{
        //    if (id != casoCovid.CasoCovidId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(casoCovid).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CasoCovidExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/ReporteCaso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CasoCovid>> PostCasoCovid(CasoCovid casoCovid)
        {
            _context.CasosCovid.Add(casoCovid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasoCovid", new { id = casoCovid.CasoCovidId }, casoCovid);
        }

        // DELETE: api/ReporteCaso/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<CasoCovid>> DeleteCasoCovid(int id)
        //{
        //    var casoCovid = await _context.CasosCovid.FindAsync(id);
        //    if (casoCovid == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CasosCovid.Remove(casoCovid);
        //    await _context.SaveChangesAsync();

        //    return casoCovid;
        //}

        private bool CasoCovidExists(int id)
        {
            return _context.CasosCovid.Any(e => e.CasoCovidId == id);
        }
    }
}
