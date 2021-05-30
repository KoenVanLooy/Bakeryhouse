using BakeryHouse.Data.Repository;
using BakeryHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BakeryHouseContext _context;
        private IGenericRepository<Order> orderRepository;
        private IGenericRepository<Product> productRepository;
        private IGenericRepository<Klant> klantRepository;
        private IGenericRepository<Afhaalpunt> afhaalpuntRepository;
        public  UnitOfWork(BakeryHouseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(_context);
                }
                return orderRepository;
            }
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }

        }
        public IGenericRepository<Klant> KlantRepository
        {
            get
            {
                if (this.klantRepository == null)
                {
                    this.klantRepository = new GenericRepository<Klant>(_context);
                }
                return klantRepository;
            }
        }
        public IGenericRepository<Afhaalpunt> AfhaalpuntRepository
        {
            get
            {
                if (this.afhaalpuntRepository == null)
                {
                    this.afhaalpuntRepository = new GenericRepository<Afhaalpunt>(_context);
                }
                return afhaalpuntRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
