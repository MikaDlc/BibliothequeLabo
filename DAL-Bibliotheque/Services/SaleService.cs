﻿using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class SaleService : ISaleRepository<Sale>
    {
        private DataContext _context;
        public SaleService(DataContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Sale> Get()
        {
            return _context.Sales.Select(s => s.ToDAL());
        }

        public Sale Get(int id)
        {
            try
            {
                return _context.Sales.Include(s => s.Books)
                                         .Include(s => s.Client)
                                         .First(s => s.SaleID == id).ToDALDetails();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid ID");
            }
        }
        public int Insert(Sale entity)
        {
            try
            {
                var sale = entity.ToEF();
                sale.Books = entity.Books.Select(b => _context.Books.Find(b.BookID)).ToList();
                _context.Sales.Add(sale);
                _context.SaveChanges();
                return sale.SaleID;
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Invalid Client");
            }
        }
    }
}
