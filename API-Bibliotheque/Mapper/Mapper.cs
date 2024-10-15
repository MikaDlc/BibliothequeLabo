using API_Bibliotheque.Models.Auth;
using API_Bibliotheque.Models.Get;
using API_Bibliotheque.Models.GetDetails;
using API_Bibliotheque.Models.Post;
using System.IdentityModel.Tokens.Jwt;
using BLL = BLL_Bibliotheque.Entities;
namespace API_Bibliotheque.Mapper
{
    internal static class Mapper
    {
        // Book
        internal static BLL.Book ToBLL(this BookPost book)
        {
            try
            {
                List<BLL.LibraryStock> bookLibraries = new List<BLL.LibraryStock>();
                for (int i = 0; i < book.Libraries.Count; i++)
                {
                    bookLibraries.Add(new BLL.LibraryStock { LibraryID = book.Libraries[i], Stock = book.LibraryQuantity[i] });
                }

                return new BLL.Book
                {
                    Title = book.Title,
                    Edition = book.Edition,
                    EditionDate = book.EditionDate,
                    Price = book.Price,
                    Authors = book.Authors.Select(a => new BLL.Author { AuthorID = a }).ToList(),
                    Genres = book.Genres.Select(g => new BLL.Genre { GName = g }).ToList(),
                    Libraries = bookLibraries,
                };
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentException("The number of libraries and the number of library quantities must be the same.");
            }
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

        internal static BookDetails ToAPIDetails(this BLL.Book book)
        {
            return new BookDetails
            {
                BookId = book.BookID,
                Title = book.Title,
                Edition = book.Edition,
                EditionDate = book.EditionDate,
                Price = book.Price,
                Authors = book.Authors.Select(a => a.ToAPI()).ToList(),
                Genres = book.Genres.Select(g => g.ToAPI()).ToList(),
                Libraries = book.Libraries.Select(l => l.ToAPI()).ToList(),
                Sales = book.Sales.Select(s => s.ToAPI()).ToList(),
                Leases = book.Leases.Select(l => l.ToAPI()).ToList()
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

        internal static AuthorDetails ToAPIDetails(this BLL.Author author)
        {
            return new AuthorDetails
            {
                AuthorId = author.AuthorID,
                FirstName = author.FirstName,
                Name = author.Name,
                Books = author.Books.Select(b => b.ToAPI()).ToList()
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

        internal static ClientDetails ToAPIDetails(this BLL.Client client)
        {
            return new ClientDetails
            {
                ClientId = client.ClientID,
                FirsName = client.FirstName,
                Name = client.Name,
                Email = client.Email,
                City = client.City,
                PostalCode = client.PostalCode,
                Street = client.Street,
                Country = client.Country,
                NumberH = client.NumberH,
                Sales = client.Sales.Select(s => s.ToAPI()).ToList(),
                Leases = client.Leases.Select(l => l.ToAPI()).ToList()
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

        internal static GenreDetails ToAPIDetails(this BLL.Genre genre)
        {
            return new GenreDetails
            {
                GName = genre.GName,
                Books = genre.Books.Select(b => b.ToAPI()).ToList()
            };
        }

        // Lease
        internal static BLL.Lease ToBLL(this LeasePost lease)
        {
            return new BLL.Lease
            {
                Price = lease.Price,
                LibraryID = lease.LibraryID,
                Books = lease.Books.Select(b => new BLL.Book { BookID = b }).ToList()
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

        internal static LeaseDetails ToAPIDetails(this BLL.Lease lease)
        {
            return new LeaseDetails
            {
                LeaseId = lease.LeaseID,
                LeaseDate = lease.LeaseDate,
                ReturnDate = lease.ReturnDate,
                Client = lease.Client.ToAPI(),
                Price = lease.Price,
                Books = lease.Books.Select(b => b.ToAPI()).ToList()
            };
        }

        // Sale
        internal static BLL.Sale ToBLL(this SalePost sale)
        {
            return new BLL.Sale
            {
                Price = sale.Price,
                LibraryID = sale.LibraryID,
                Books = sale.Books.Select(b => new BLL.Book { BookID = b }).ToList()
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

        internal static SaleDetails ToAPIDetails(this BLL.Sale sale)
        {
            return new SaleDetails
            {
                SaleID = sale.SaleID,
                DateSale = sale.DateSale,
                Client = sale.Client.ToAPI(),
                Price = sale.Price,
                Books = sale.Books.Select(b => b.ToAPI()).ToList()
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

        internal static LibraryDetails ToAPIDetails(this BLL.Library library)
        {
            return new LibraryDetails
            {
                LibraryID = library.LibraryID,
                City = library.City,
                PostalCode = library.PostalCode,
                Street = library.Street,
                Country = library.Country,
                NumberH = library.NumberH,
                Books = library.Books.Select(b => b.ToAPI()).ToList(),
            };
        }

        // LibraryStock

        internal static LibraryStockDetails ToAPI(this BLL.LibraryStock libraryStock)
        {
            return new LibraryStockDetails
            {
                LibraryID = libraryStock.LibraryID,
                City = libraryStock.City,
                PostalCode = libraryStock.PostalCode,
                Street = libraryStock.Street,
                Country = libraryStock.Country,
                NumberH = libraryStock.NumberH,
                Stock = libraryStock.Stock
            };
        }

        // Auth

        internal static Auth ToAPI(this BLL.Auth auth)
        {
            return new Auth
            {
                Id = auth.Id,
                IsAdmin = auth.IsAdmin
            };
        }

        // Extraction token

        internal static int GetId(this HttpContext header)
        {

            string tokenFromRequest = header.Request.Headers["Authorization"];
            string token = tokenFromRequest.Substring(7, tokenFromRequest.Length - 7);
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            return int.Parse(jwt.Claims.First(x => x.Type == "UserId").Value);
        }
    }
}
