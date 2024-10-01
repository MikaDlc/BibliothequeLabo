using BLL = BLL_Bibliotheque.Entities;
using DAL = DAL_Bibliotheque.Entities;
namespace BLL_Bibliotheque.Mapper
{
    internal static class Mapper
    {

        public static BLL.Book ToBLL(this DAL.Book entity)
        {
            return new BLL.Book
            {
                BookID = entity.BookID,
                Title = entity.Title,
                Edition = entity.Edition,
                EditionDate = entity.EditionDate,
                Price = entity.Price,
            };
        }

        public static DAL.Book ToDAL(this BLL.Book entity)
        {
            return new DAL.Book
            {
                BookID = entity.BookID,
                Title = entity.Title,
                Edition = entity.Edition,
                EditionDate = entity.EditionDate,
                Price = entity.Price,
            };
        }
    }
}
