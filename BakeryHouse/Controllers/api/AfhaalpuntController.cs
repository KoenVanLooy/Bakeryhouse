using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BakeryHouse.Data;
using BakeryHouse.Models;
using Microsoft.Extensions.Logging;
using BakeryHouse.Data.UnitOfWork;

namespace BakeryHouse.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfhaalpuntController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;

        public AfhaalpuntController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Afhaalpunt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Afhaalpunt>>> GetAfhaalpunten()
        {
            return await _uow.AfhaalpuntRepository.GetAll().ToListAsync();
        }

        // GET: api/Afhaalpunt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Afhaalpunt>> GetAfhaalpunt(int id)
        {
            var afhaalpunt = await _uow.AfhaalpuntRepository.GetById(id);

            if (afhaalpunt == null)
            {
                return NotFound();
            }

            return afhaalpunt;
        }

        // PUT: api/Afhaalpunt/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAfhaalpunt(int id, Afhaalpunt afhaalpunt)
        {
            if (id != afhaalpunt.AfhaalpuntId)
            {
                return BadRequest();
            }

            _uow.AfhaalpuntRepository.Update(afhaalpunt);

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

        // POST: api/Afhaalpunt
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Afhaalpunt>> PostAfhaalpunt(Afhaalpunt afhaalpunt)
        {
            _uow.AfhaalpuntRepository.Create(afhaalpunt);
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Foute save naar database");
            }


            return CreatedAtAction("GetAfhaalpunt", new { id = afhaalpunt.AfhaalpuntId }, afhaalpunt);
        }

        // DELETE: api/Afhaalpunt/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Afhaalpunt>> DeleteAfhaalpunt(int id)
        {
            var afhaalpunt = await _uow.AfhaalpuntRepository.GetById(id);
            if (afhaalpunt == null)
            {
                return NotFound();
            }

            _uow.AfhaalpuntRepository.Delete(afhaalpunt);
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
