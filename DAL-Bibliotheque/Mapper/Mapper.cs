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

        public static DAL.Book ToDALDetails(this EF.Book entity)
        {
            return new DAL.Book
            {
                BookID = entity.BookID,
                Title = entity.Title,
                Edition = entity.Edition,
                EditionDate = entity.EditionDate,
                Price = entity.Price,
                BookLibraries = entity.BookLibraries.Select(bl => bl.ToDAL()).ToList(),
                BookAuthors = entity.BookAuthors.Select(ba => ba.ToDAL()).ToList(),
                BookGenres = entity.BookGenres.Select(bg => bg.ToDAL()).ToList()
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

        public static DAL.Author ToDALDetails(this EF.Author entity)
        {
            return new DAL.Author
            {
                AuthorID = entity.AuthorID,
                FirstName = entity.FirstName,
                Name = entity.Name,
                BookAuthors = entity.BookAuthors.Select(ba => ba.ToDAL()).ToList()
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

        public static DAL.Client ToDALDetails(this EF.Client entity)
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
                Street = entity.Street,
                Leases = entity.Leases.Select(l => l.ToDAL()).ToList(),
                Sales = entity.Sales.Select(s => s.ToDAL()).ToList()
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

        public static DAL.Genre ToDALDetails(this EF.Genre entity)
        {
            return new DAL.Genre
            {
                GName = entity.GName,
                BookGenres = entity.BookGenres.Select(bg => bg.ToDAL()).ToList()
            };
        }

        // Lease
        public static EF.Lease ToEF(this DAL.Lease entity)
        {
            return new EF.Lease
            {
                LeaseID = entity.LeaseID,
                LeaseDate = entity.LeaseDate,
                ReturnDate = entity.ReturnDate,
                ClientID = entity.ClientID,
                Price = entity.Price
            };
        }

        public static DAL.Lease ToDAL(this EF.Lease entity)
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

        public static DAL.Lease ToDALDetails(this EF.Lease entity)
        {
            return new DAL.Lease
            {
                LeaseID = entity.LeaseID,
                LeaseDate = entity.LeaseDate,
                ReturnDate = entity.ReturnDate,
                ClientID = entity.ClientID,
                Client = entity.Client.ToDAL(),
                Price = entity.Price,
                BookLeases = entity.BookLeases.Select(bl => bl.ToDAL()).ToList()
            };
        }

        // Sale
        public static EF.Sale ToEF(this DAL.Sale entity)
        {
            return new EF.Sale
            {
                SaleID = entity.SaleID,
                DateSale = entity.DateSale,
                ClientID = entity.ClientID,
                Price = entity.Price
            };
        }

        public static DAL.Sale ToDAL(this EF.Sale entity)
        {
            return new DAL.Sale
            {
                SaleID = entity.SaleID,
                DateSale = entity.DateSale,
                ClientID = entity.ClientID,
                Price = entity.Price
            };
        }

        public static DAL.Sale ToDALDetails(this EF.Sale entity)
        {
            return new DAL.Sale
            {
                SaleID = entity.SaleID,
                DateSale = entity.DateSale,
                ClientID = entity.ClientID,
                Client = entity.Client.ToDAL(),
                Price = entity.Price,
                BookSales = entity.BookSales.Select(bs => bs.ToDAL()).ToList()
            };
        }

        // Library
        public static EF.Library ToEF(this DAL.Library entity)
        {
            return new EF.Library
            {
                LibraryID = entity.LibraryID,
                Street = entity.Street,
                NumberH = entity.NumberH,
                PostalCode = entity.PostalCode,
                City = entity.City,
                Country = entity.Country
            };
        }

        public static DAL.Library ToDAL(this EF.Library entity)
        {
            return new DAL.Library
            {
                LibraryID = entity.LibraryID,
                Street = entity.Street,
                NumberH = entity.NumberH,
                PostalCode = entity.PostalCode,
                City = entity.City,
                Country = entity.Country
            };
        }

        public static DAL.Library ToDALDetails(this EF.Library entity)
        {
            return new DAL.Library
            {
                LibraryID = entity.LibraryID,
                Street = entity.Street,
                NumberH = entity.NumberH,
                PostalCode = entity.PostalCode,
                City = entity.City,
                Country = entity.Country,
                BookLibraries = entity.BookLibraries.Select(bl => bl.ToDAL()).ToList()
            };
        }

        // BookLibrairy
        private static DAL.BookLibrary ToDAL(this EF.BookLibrary entity)
        {
            return new DAL.BookLibrary
            {
                BookID = entity.BookID,
                Book = entity.Book.ToDAL(),
                LibraryID = entity.LibraryID,
                Library = entity.Library.ToDAL(),
                QDispo = entity.QDispo
            };
        }

        public static EF.BookLibrary ToEF(this DAL.BookLibrary entity)
        {
            return new EF.BookLibrary
            {
                BookID = entity.BookID,
                LibraryID = entity.LibraryID,
                QDispo = entity.QDispo
            };
        }

        // BookAuthor
        private static DAL.BookAuthor ToDAL(this EF.BookAuthor entity)
        {
            return new DAL.BookAuthor
            {
                BookID = entity.BookID,
                Book = entity.Book.ToDAL(),
                AuthorID = entity.AuthorID,
                Author = entity.Author.ToDAL(),
            };
        }

        public static EF.BookAuthor ToEF(this DAL.BookAuthor entity)
        {
            return new EF.BookAuthor
            {
                BookID = entity.BookID,
                AuthorID = entity.AuthorID,
            };
        }

        // BookGenre
        private static DAL.BookGenre ToDAL(this EF.BookGenre entity)
        {
            return new DAL.BookGenre
            {
                BookID = entity.BookID,
                Book = entity.Book.ToDAL(),
                GName = entity.GName,
                Genre = entity.Genre.ToDAL(),
            };
        }

        public static EF.BookGenre ToEF(this DAL.BookGenre entity)
        {
            return new EF.BookGenre
            {
                BookID = entity.BookID,
                GName = entity.GName,
            };
        }

        // BookSale
        private static DAL.BookSale ToDAL(this EF.BookSale entity)
        {
            return new DAL.BookSale
            {
                BookID = entity.BookID,
                Book = entity.Book.ToDAL(),
                SaleID = entity.SaleID,
                Sale = entity.Sale.ToDAL(),
            };
        }

        public static EF.BookSale ToEF(this DAL.BookSale entity)
        {
            return new EF.BookSale
            {
                BookID = entity.BookID,
                SaleID = entity.SaleID,
            };
        }

        // BookLease
        private static DAL.BookLease ToDAL(this EF.BookLease entity)
        {
            return new DAL.BookLease
            {
                BookID = entity.BookID,
                Book = entity.Book.ToDAL(),
                LeaseID = entity.LeaseID,
                Lease = entity.Lease.ToDAL(),
            };
        }

        public static EF.BookLease ToEF(this DAL.BookLease entity)
        {
            return new EF.BookLease
            {
                BookID = entity.BookID,
                LeaseID = entity.LeaseID,
            };
        }
    }
}
