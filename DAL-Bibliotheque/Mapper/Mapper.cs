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

        // Client
        public static EF.Client ToEF(this DAL.Client entity)
        {
            return new EF.Client
            {
                ClientID = entity.ClientID,
                FirstName = entity.FirstName,
                Name = entity.Name,
                Street = entity.Street,
                NumberH = entity.NumberH,
                PostalCode = entity.PostalCode,
                City = entity.City,
                Country = entity.Country,
                Email = entity.Email,
                Passwd = entity.Passwd,
                Salage = "entity.Salage" // A definir avec l'autentification
            };
        }

        public static DAL.Client ToDAL(this EF.Client entity)
        {
            return new DAL.Client
            {
                ClientID = entity.ClientID,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Passwd = entity.Passwd,
                Name = entity.Name,
                City = entity.City,
                Country = entity.Country,
                NumberH = entity.NumberH,
                PostalCode = entity.PostalCode,
                Street = entity.Street
            };
        }

        // Genre
        public static EF.Genre ToEF(this DAL.Genre entity)
        {
            return new EF.Genre
            {
                GName = entity.GName,
            };
        }

        public static DAL.Genre ToDAL(this EF.Genre entity)
        {
            return new DAL.Genre
            {
                GName = entity.GName,
            };
        }
    }
}
