using API_Bibliotheque.Models;
using API = API_Bibliotheque.Models;
using BLL = BLL_Bibliotheque.Entities;
namespace API_Bibliotheque.Mapper
{
    internal static class Mapper
    {
        // Book
        internal static BLL.Book ToBLL(this API.BookPost book)
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
        internal static BLL.Author ToBLL(this API.AuthorPost author)
        {
            return new BLL.Author
            {
                FirstName = author.FirstName,
                Name = author.Name,
            };
        }
    }
}
