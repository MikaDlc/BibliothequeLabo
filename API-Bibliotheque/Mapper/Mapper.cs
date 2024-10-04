using API_Bibliotheque.Models.Get;
using API_Bibliotheque.Models.Post;
using API_Bibliotheque.Models.Put;
using BLL = BLL_Bibliotheque.Entities;
namespace API_Bibliotheque.Mapper
{
    internal static class Mapper
    {
        // Book
        internal static BLL.Book ToBLL(this BookPost book)
        { 
            return new BLL.Book
            {
                Title = book.Title,
                Edition = book.Edition,
                EditionDate = book.EditionDate,
                Price = book.Price,
                BookAuthors = book.Authors.Select(a => new BLL.BookAuthor { AuthorID = a }).ToList(),
                BookGenres = book.Genres.Select(g => new BLL.BookGenre { GName = g }).ToList(),
                BookLibraries = book.Libraries.Select(l => new BLL.BookLibrary { LibraryID = l }).ToList(),
            };
        }

        internal static BookGet ToAPI(this BLL.Book book)
        {
            return new BookGet
            {
                BookId = book.BookID,
                Title = book.Title,
                Edition = book.Edition,
                EditionDate = book.EditionDate,
                Price = book.Price,
            };
        }

        // Author
        internal static BLL.Author ToBLL(this AuthorPost author)
        {
            return new BLL.Author
            {
                FirstName = author.FirstName,
                Name = author.Name,
            };
        }

        internal static AuthorGet ToAPI(this BLL.Author author)
        {
            return new AuthorGet
            {
                AuthorId = author.AuthorID,
                FirstName = author.FirstName,
                Name = author.Name,
            };
        }

        // Client
        internal static BLL.Client ToBLL(this ClientPost client)
        {
            return new BLL.Client
            {
                FirstName = client.FirsName,
                Name = client.Name,
                Email = client.Email,
                Passwd = client.Passwd,
                City = client.City,
                PostalCode = client.PostalCode,
                Street = client.Street,
                Country = client.Country,
                NumberH = client.NumberH
            };
        }

        internal static ClientGet ToAPI(this BLL.Client client)
        {
            return new ClientGet
            {
                ClientId = client.ClientID,
                FirsName = client.FirstName,
                Name = client.Name,
                Email = client.Email,
            };
        }

        // Genre
        internal static BLL.Genre ToBLL(this GenrePost genre)
        {
            return new BLL.Genre
            {
                GName = genre.GName,
            };
        }

        internal static GenreGet ToAPI(this BLL.Genre genre)
        {
            return new GenreGet
            {
                GName = genre.GName,
            };
        }

        // Lease
        internal static BLL.Lease ToBLL(this LeasePost lease)
        {
            return new BLL.Lease
            {
                LeaseDate = lease.LeaseDate,
                ClientID = lease.ClientID,
                Price = lease.Price
            };
        }

        internal static BLL.Lease ToBLL(this LeasePut lease)
        {
            return new BLL.Lease
            {
                ReturnDate = lease.ReturnDate
            };
        }

        internal static LeaseGet ToAPI(this BLL.Lease lease)
        {
            return new LeaseGet
            {
                LeaseId = lease.LeaseID,
                LeaseDate = lease.LeaseDate,
                ReturnDate = lease.ReturnDate,
                ClientId = lease.ClientID,
                Price = lease.Price
            };
        }

        // Sale
        internal static BLL.Sale ToBLL(this SalePost sale)
        {
            return new BLL.Sale
            {
                DateSale = sale.DateSale,
                ClientID = sale.ClientID,
                Price = sale.Price
            };
        }

        internal static SaleGet ToAPI(this BLL.Sale sale)
        {
            return new SaleGet
            {
                SaleID = sale.SaleID,
                DateSale = sale.DateSale,
                ClientID = sale.ClientID,
                Price = sale.Price
            };
        }

        // Library
        internal static BLL.Library ToBLL(this LibraryPost library)
        {
            return new BLL.Library
            {
                City = library.City,
                PostalCode = library.PostalCode,
                Street = library.Street,
                Country = library.Country,
                NumberH = library.NumberH
            };
        }

        internal static LibraryGet ToAPI(this BLL.Library library)
        {
            return new LibraryGet
            {
                LibraryID = library.LibraryID,
                City = library.City,
                PostalCode = library.PostalCode,
                Street = library.Street,
                Country = library.Country,
                NumberH = library.NumberH
            };
        }
    }
}
