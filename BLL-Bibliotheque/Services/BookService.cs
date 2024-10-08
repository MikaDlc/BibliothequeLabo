﻿using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using EF_Bibliotheque;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class BookService : IBookRepository<Book>
    {
        private IBookRepository<DAL.Book> _bookService;
        private IBookAuthorRepository<DAL.BookAuthor> _bookAuthorService;
        private IBookGenreRepository<DAL.BookGenre> _bookGenreService;
        private IBookLibraryRepository<DAL.BookLibrary> _bookLibraryService;

        public BookService(IBookRepository<DAL.Book> Service,
                           IBookAuthorRepository<DAL.BookAuthor> bookAuthorService,
                           IBookGenreRepository<DAL.BookGenre> bookGenreService,
                           IBookLibraryRepository<DAL.BookLibrary> bookLibraryService)
        {
            _bookService = Service;
            _bookAuthorService = bookAuthorService;
            _bookGenreService = bookGenreService;
            _bookLibraryService = bookLibraryService;
        }

        public IEnumerable<Book> Get()
        {
            return _bookService.Get().Select(b => b.ToBLL());
        }

        public Book Get(int id)
        {
            return _bookService.Get(id).ToBLLDetails();
        }

        public int Insert(Book entity)
        {
            int BookID = 0;
            try
            {
                BookID = _bookService.Insert(entity.ToDAL());
                foreach (LibraryStock bookLibrary in entity.Libraries)
                    _bookLibraryService.Insert(new DAL.BookLibrary { BookID = BookID, LibraryID = bookLibrary.LibraryID, QDispo = bookLibrary.Stock });
                foreach (Author bookAuthor in entity.Authors)
                    _bookAuthorService.Insert(new DAL.BookAuthor { BookID = BookID, AuthorID = bookAuthor.AuthorID });
                foreach (Genre bookGenre in entity.Genres)
                    _bookGenreService.Insert(new DAL.BookGenre { BookID = BookID, GName = bookGenre.GName });
                return BookID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
