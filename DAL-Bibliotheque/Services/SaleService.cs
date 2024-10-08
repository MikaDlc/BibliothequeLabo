using Commun_Bibliotheque.Repositories;
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

        public IEnumerable<Sale> Get()
        {
            return _context.Sales.Select(s => s.ToDAL());
        }

        public Sale Get(int id)
        {
            try
            {
                return _context.Sales.Include(s => s.BookSales).ThenInclude(bs => bs.Book)
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
