using BookApp.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BookApp.Services.BookService))]
namespace BookApp.Services
{
    class BookService : IBookService
    {
        Book[] _books;

        void Initialize ()
        {
            _books = new Book[]
            {
                new Book
                {
                    Title = "Remote: Office Not Required",
                    Author = "Jason Fried",
                    CoverImageUrl = "http://ecx.images-amazon.com/images/I/41KQs2jNyaL._SY344_BO1,204,203,200_.jpg",
                    Rating = 4
                },
                new Book
                {
                    Title = "Papillion",
                    Author = "Henri Charrière",
                    CoverImageUrl = "http://frixos.files.wordpress.com/2009/04/papillon_book.jpg",
                    Rating = 3.5f,
                },
                new Book
                {
                    Title = "The Dark Tower: The Gunslinger",
                    Author = "Stephen King",
                    CoverImageUrl = "http://3.bp.blogspot.com/-ASeA6F81WTY/UTeQmRhyaNI/AAAAAAAAAUU/VDzSPwV99o4/s1600/the-dark-tower-gunslinger-bk-i-9781444723441.jpg",
                    Rating = 5
                },
                new Book
                {
                    Title = "Artemis Fowl",
                    Author = "Eoin Colfer",
                    CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1477286232l/32733787.jpg",
                    Rating = 5
                },
                new Book
                {
                    Title = "Sideways Arithmetic From Wayside School",
                    Author = "Louis Sachar",
                    CoverImageUrl = "https://th.bing.com/th/id/OIP.qviz9HsX4Igzz0d-SHqqpAHaKv?pid=Api&w=124&h=180&c=7",
                    Rating = 5
                }
            };
        }

        public Task<Book[]> FindBooksAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<Book[]> GetReviewedBooksAsync()
        {
           if (_books == null)
            {
                await Task.Delay(1000);
                Initialize();
            }
            return _books;
        }

        public Task ReviewBookAsync(Book book, string review)
        {
            throw new NotImplementedException();
        }
    }
}
