using BLL = BLL_Bibliotheque.Entities;
using DAL = DAL_Bibliotheque.Entities;
namespace BLL_Bibliotheque.Mapper
{
    internal static class Mapper
    {
        // Book
        public static BLL.Book ToBLLDetails(this DAL.Book entity)
        {
            return new BLL.Book
            {
                BookID = entity.BookID,
                Title = entity.Title,
                Edition = entity.Edition,
                EditionDate = entity.EditionDate,
                Price = entity.Price,
                Authors = entity.BookAuthors.Select(ba => ba.Author.ToBLL()).ToList(),
                Genres = entity.BookGenres.Select(bg => bg.Genre.ToBLL()).ToList(),
                Leases = entity.BookLeases.Select(bl => bl.Lease.ToBLL()).ToList(),
                Sales = entity.BookSales.Select(bs => bs.Sale.ToBLL()).ToList(),
                Libraries = entity.BookLibraries.Select(bl => 
                    new BLL.LibraryStock
                    {
                        LibraryID = bl.LibraryID,
                        City = bl.Library.City,
                        PostalCode = bl.Library.PostalCode,
                        Street = bl.Library.Street,
                        Country = bl.Library.Country,
                        NumberH = bl.Library.NumberH,
                        Stock = bl.QDispo
                    }).ToList(),
            };
        }

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
        public static BLL.Author ToBLLDetails(this DAL.Author entity)
        {
            return new BLL.Author
            {
                AuthorID = entity.AuthorID,
                FirstName = entity.FirstName,
                Name = entity.Name,
                Books = entity.BookAuthors.Select(ba => ba.Book.ToBLL()).ToList(),
            };
        }
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
        public static BLL.Client ToBLLDetails(this DAL.Client entity)
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
                NumberH = entity.NumberH,
                Leases = entity.Leases.Select(l => l.ToBLL()).ToList(),
                Sales = entity.Sales.Select(s => s.ToBLL()).ToList(),
            };
        }

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
        public static BLL.Genre ToBLLDetails(this DAL.Genre entity)
        {
            return new BLL.Genre
            {
                GName = entity.GName,
                Books = entity.BookGenres.Select(bg => bg.Book.ToBLL()).ToList(),
            };
        }
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
        public static BLL.Lease ToBLLDetails(this DAL.Lease entity)
        {
            return new BLL.Lease
            {
                LeaseID = entity.LeaseID,
                LeaseDate = entity.LeaseDate,
                ReturnDate = entity.ReturnDate,
                ClientID = entity.ClientID,
                Price = entity.Price,
                Client = entity.Client.ToBLL(),
                Books = entity.BookLeases.Select(b => b.Book.ToBLL()).ToList(),
            };
        }
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
        public static BLL.Sale ToBLLDetails(this DAL.Sale entity)
        {
            return new BLL.Sale
            {
                SaleID = entity.SaleID,
                DateSale = entity.DateSale,
                ClientID = entity.ClientID,
                Price = entity.Price,
                Client = entity.Client.ToBLL(),
                Books = entity.BookSales.Select(b => b.Book.ToBLL()).ToList(),
            };
        }
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
        public static BLL.Library ToBLLDetails(this DAL.Library entity)
        {
            return new BLL.Library
            {
                LibraryID = entity.LibraryID,
                City = entity.City,
                PostalCode = entity.PostalCode,
                Street = entity.Street,
                Country = entity.Country,
                NumberH = entity.NumberH,
                Books = entity.BookLibraries.Select(bl => bl.Book.ToBLL()).ToList(),
            };
        }
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

        // BookLibrary
        private static BLL.BookLibrary ToBLL(this DAL.BookLibrary entity)
        {
            return new BLL.BookLibrary
            {
                BookID = entity.BookID,
                Book = entity.Book.ToBLL(),
                LibraryID = entity.LibraryID,
                Library = entity.Library.ToBLL(),
                QDispo = entity.QDispo,
            };
        }

        // BookAuthor
        private static BLL.BookAuthor ToBLL(this DAL.BookAuthor entity)
        {
            return new BLL.BookAuthor
            {
                BookID = entity.BookID,
                Book = entity.Book.ToBLL(),
                AuthorID = entity.AuthorID,
                Author = entity.Author.ToBLL(),
            };
        }

        // BookGenre
        private static BLL.BookGenre ToBLL(this DAL.BookGenre entity)
        {
            return new BLL.BookGenre
            {
                BookID = entity.BookID,
                Book = entity.Book.ToBLL(),
                GName = entity.GName,
                Genre = entity.Genre.ToBLL(),
            };
        }

        // BookSale
        private static BLL.BookSale ToBLL(this DAL.BookSale entity)
        {
            return new BLL.BookSale
            {
                BookID = entity.BookID,
                Book = entity.Book.ToBLL(),
                SaleID = entity.SaleID,
                Sale = entity.Sale.ToBLL(),
            };
        }

        // BookLease
        private static BLL.BookLease ToBLL(this DAL.BookLease entity)
        {
            return new BLL.BookLease
            {
                BookID = entity.BookID,
                Book = entity.Book.ToBLL(),
                LeaseID = entity.LeaseID,
                Lease = entity.Lease.ToBLL(),
            };
        }
    }
}
