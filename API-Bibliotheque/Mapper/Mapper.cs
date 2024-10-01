using API_Bibliotheque.Models;
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
    }
}
