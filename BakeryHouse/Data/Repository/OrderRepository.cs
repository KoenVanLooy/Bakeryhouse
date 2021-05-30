using BakeryHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BakeryHouseContext _context;
        public OrderRepository(BakeryHouseContext context)
        {
            _context = context;
        }
        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public IEnumerable<Order> All()
        {
            return _context.Orders.ToList();
        }

        public Order Find(int OrderId)
        {
            return _context.Orders.Find(OrderId);
        }

        public IQueryable<Order> Search()
        {
            return _context.Orders.AsQueryable();
        }
    }
}
