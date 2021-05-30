using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BakeryHouse.Data;
using BakeryHouse.Models;
using BakeryHouse.Data.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace BakeryHouse.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlantController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;
        public KlantController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Klant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klant>>> GetKlanten()
        {
            return await _uow.KlantRepository.GetAll().ToListAsync();
        }

        // GET: api/Klant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Klant>> GetKlant(int id)
        {
            var klant = await _uow.KlantRepository.GetById(id);

            if (klant == null)
            {
                return NotFound();
            }

            return klant;
        }

        // PUT: api/Klant/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlant(int id, Klant klant)
        {
            if (id != klant.KlantId)
            {
                return BadRequest();
            }

            _uow.KlantRepository.Update(klant);

            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
            return NoContent();
        }

        // POST: api/Klant
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Klant>> PostKlant(Klant klant)
        {
            _uow.KlantRepository.Create(klant);
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Foute save naar database");
            }


            return CreatedAtAction("GetKlant", new { id = klant.KlantId }, klant);
        }

        // DELETE: api/Klant/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Klant>> DeleteKlant(int id)
        {
            var klant = await _uow.KlantRepository.GetById(id);
            if (klant == null)
            {
                return NotFound();
            }

            _uow.KlantRepository.Delete(klant);
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Foute save naar database");
            }
            return NoContent();
        }
    }
}
