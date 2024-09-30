namespace EF_Bibliotheque.Entities
{
    internal class BookLibrary
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int LibraryID { get; set; }
        public Library Library { get; set; }
        public int QDispo { get; set; }
    }
}
