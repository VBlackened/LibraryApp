
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryApp.Controllers
{
    public class BookController
    {
        private ObservableCollection<BookModel> _books = new();

        public ObservableCollection<BookModel> GetAllBooks()
        {
            return _books;
        }

        public string? AddBook(string title, string author, int year)
        {
            var book = new BookModel
            {
                Title = title,
                Author = author,
                YearOfRelease = year
            };

            var validation = book.Validate();
            if (validation != null)
                return validation;

            book.Id = _books.Count + 1;
            _books.Add(book);
            return null;
        }

        public string? EditBook(BookModel book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
                return "Book not found.";

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.YearOfRelease = book.YearOfRelease;

            var validation = book.Validate();
            if (validation != null)
                return validation;

            return null;
        }

        public void DeleteBook(BookModel book)
        {
            _books.Remove(book);
        }

        

    }
}



//Controller:
//Utwórz klasę BookController, która:
//przechowuje listę książek (ObservableCollection<BookModel>),

//ma metody:
//AddBook(BookModel book)
//EditBook(BookModel book)
//DeleteBook(BookModel book)
//GetAllBooks()
