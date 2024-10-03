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
            return _context.Sales.Include(s => s.BookSales).ThenInclude(bs => bs.Book)
                                 .Include(s => s.Client)
                                 .First(s => s.SaleID == id).ToDALDetails();
        }

        public bool Insert(Sale entity)
        {
            try
            {
                _context.Sales.Add(entity.ToEF());
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
