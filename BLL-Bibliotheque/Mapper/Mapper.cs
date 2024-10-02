using BLL = BLL_Bibliotheque.Entities;
using DAL = DAL_Bibliotheque.Entities;
namespace BLL_Bibliotheque.Mapper
{
    internal static class Mapper
    {
        // Book
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

        // Author
        public static BLL.Author ToBLL(this DAL.Author entity)
        {
            return new BLL.Author
            {
                AuthorID = entity.AuthorID,
                FirstName = entity.FirstName,
                Name = entity.Name,
            };
        }

        public static DAL.Author ToDAL(this BLL.Author entity)
        {
            return new DAL.Author
            {
                AuthorID = entity.AuthorID,
                FirstName = entity.FirstName,
                Name = entity.Name,
            };
        }

        // Client
        public static BLL.Client ToBLL(this DAL.Client entity)
        {
            return new BLL.Client
            {
                ClientID = entity.ClientID,
                FirstName = entity.FirstName,
                Name = entity.Name,
                Email = entity.Email,
                Passwd = entity.Passwd,
                City = entity.City,
                PostalCode = entity.PostalCode,
                Street = entity.Street,
                Country = entity.Country,
                NumberH = entity.NumberH
            };
        }

        public static DAL.Client ToDAL(this BLL.Client entity)
        {
            return new DAL.Client
            {
                ClientID = entity.ClientID,
                FirstName = entity.FirstName,
                Name = entity.Name,
                Email = entity.Email,
                Passwd = entity.Passwd,
                City = entity.City,
                PostalCode = entity.PostalCode,
                Street = entity.Street,
                Country = entity.Country,
                NumberH = entity.NumberH
            };
        }

        // Genre
        public static BLL.Genre ToBLL(this DAL.Genre entity)
        {
            return new BLL.Genre
            {
                GName = entity.GName,
            };
        }

        public static DAL.Genre ToDAL(this BLL.Genre entity)
        {
            return new DAL.Genre
            {
                GName = entity.GName,
            };
        }

        // Lease
        public static BLL.Lease ToBLL(this DAL.Lease entity)
        {
            return new BLL.Lease
            {
                LeaseID = entity.LeaseID,
                LeaseDate = entity.LeaseDate,
                ReturnDate = entity.ReturnDate,
                ClientID = entity.ClientID,
                Price = entity.Price
            };
        }

        public static DAL.Lease ToDAL(this BLL.Lease entity)
        {
            return new DAL.Lease
            {
                LeaseID = entity.LeaseID,
                LeaseDate = entity.LeaseDate,
                ReturnDate = entity.ReturnDate,
                ClientID = entity.ClientID,
                Price = entity.Price
            };
        }

        // Sale
        public static BLL.Sale ToBLL(this DAL.Sale entity)
        {
            return new BLL.Sale
            {
                SaleID = entity.SaleID,
                DateSale = entity.DateSale,
                ClientID = entity.ClientID,
                Price = entity.Price
            };
        }

        public static DAL.Sale ToDAL(this BLL.Sale entity)
        {
            return new DAL.Sale
            {
                SaleID = entity.SaleID,
                DateSale = entity.DateSale,
                ClientID = entity.ClientID,
                Price = entity.Price
            };
        }

        // Library
        public static BLL.Library ToBLL(this DAL.Library entity)
        {
            return new BLL.Library
            {
                LibraryID = entity.LibraryID,
                City = entity.City,
                PostalCode = entity.PostalCode,
                Street = entity.Street,
                Country = entity.Country,
                NumberH = entity.NumberH,
            };
        }

        public static DAL.Library ToDAL(this BLL.Library entity)
        {
            return new DAL.Library
            {
                LibraryID = entity.LibraryID,
                City = entity.City,
                PostalCode = entity.PostalCode,
                Street = entity.Street,
                Country = entity.Country,
                NumberH = entity.NumberH,
            };
        }
    }
}
