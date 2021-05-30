using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BakeryHouse.Data;
using BakeryHouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BakeryHouse.Data.Repository;
using BakeryHouse.Data.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace BakeryHouse.Controllers.api
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;
        public OrderController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _uow.OrderRepository.GetAll().Include(x => x.Orderlijnen).ThenInclude(y => y.Product).ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _uow.OrderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            
            if (id != order.OrderId)
            {
                return BadRequest();
            }
            var orders = _uow.OrderRepository.GetAll().Include(x => x.Orderlijnen).Where(x => x.OrderId == id);
            foreach (var order1 in orders)
            {
                order1.Orderlijnen.RemoveAll(x => !order.Orderlijnen.Contains(x));
                order1.Orderlijnen.AddRange(order.Orderlijnen.Where(x => !order1.Orderlijnen.Contains(x)));
                order1.KlantId = order.KlantId;
                order1.LeverDatum = order.LeverDatum;
                order1.Orderdatum = order.Orderdatum;
                order1.AfhaalpuntId = order.AfhaalpuntId;
                _uow.OrderRepository.Update(order1);
            }

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

        // POST: api/Order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _uow.OrderRepository.Create(order);
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500,"Foute save naar database");
            }
           

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _uow.OrderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            _uow.OrderRepository.Delete(order);
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
