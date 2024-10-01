using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace DAL_Bibliotheque.Entities
{
    public class Genre : IGenre
    {
        public string GName { get; set; }
        public List<BookGenre> BookGenres { get; set; }
    }
}
