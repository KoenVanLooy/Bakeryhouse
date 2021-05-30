using BakeryHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Data.Repository
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        Order Find(int OrderId);
        IEnumerable<Order> All();

        IQueryable<Order> Search();
    }
}
