using BakeryHouse.Data.Repository;
using BakeryHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Afhaalpunt> AfhaalpuntRepository { get; }
        IGenericRepository<Klant> KlantRepository { get; }
        Task SaveAsync();
    }
}
