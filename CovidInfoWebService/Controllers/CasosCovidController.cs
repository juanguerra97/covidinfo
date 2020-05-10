using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CovidInfoWebService.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CovidInfoWebService.DataAccess;

namespace CovidInfoWebService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CasosCovidController : ControllerBase
    {
        private readonly InfoCovidDbContext _context;

        public CasosCovidController(InfoCovidDbContext context)
        {
            _context = context;
        }

        // GET: api/CasosCovid
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CasosCovid/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/nuevocaso
        [HttpPost("/nuevocaso")]
        public async Task<IActionResult> NuevoCaso([FromBody] CasoCovid casoCovid)
        {
            if (ModelState.IsValid)
            {
                this._context.Add(casoCovid);
                await this._context.SaveChangesAsync();
                return new CreatedAtRouteResult("Nuevo caso registrado", new { id = casoCovid.CasoCovidId }, casoCovid);
            }
            else
            {
                return BadRequest("Ocurrio un error con el servidor.");
            }
        }

        // PUT: api/CasosCovid/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
