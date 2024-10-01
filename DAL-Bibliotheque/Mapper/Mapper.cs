using DAL = DAL_Bibliotheque.Entities;
using EF = EF_Bibliotheque.Entities;

namespace DAL_Bibliotheque.Mapper
{
    internal static class Mapper
    {
        // Book
        public static EF.Book ToEF(this DAL.Book entity)
        {
            return new EF.Book
            {
                BookID = entity.BookID,
                Title = entity.Title,
                Edition = entity.Edition,
                EditionDate = entity.EditionDate,
                Price = entity.Price
            };
        }

        public static DAL.Book ToDAL(this EF.Book entity)
        {
            return new DAL.Book
            {
                BookID = entity.BookID,
                Title = entity.Title,
                Edition = entity.Edition,
                EditionDate = entity.EditionDate,
                Price = entity.Price
            };
        }

        // Author
        public static EF.Author ToEF(this DAL.Author entity)
        {
            return new EF.Author
            {
                AuthorID = entity.AuthorID,
                FirstName = entity.FirstName,
                Name = entity.Name
            };
        }

        public static DAL.Author ToDAL(this EF.Author entity)
        {
            return new DAL.Author
            {
                AuthorID = entity.AuthorID,
                FirstName = entity.FirstName,
                Name = entity.Name
            };
        }
    }
}
