using BookApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BookApp.Services.BookService))]
namespace BookApp.Services
{
    class BookService : IBookService
    {
        Book[] _books = new Book[]
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
                Rating = 4.5f
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
                Rating = 4.5f
            }
        };

        public Task<Book[]> FindBooksAsync(string query)
        {
            query = query.ToLower();
            var results =
                  from b in _books
                  where $"{b.Author} {b.Title}".ToLower().Contains(query)
                  select b;

            results = results.OrderBy(b => GetDamerauLevenshteinDistance($"{b.Author} {b.Title}".ToLower(), query));

            return Task.FromResult(results.ToArray());
        }

        public async Task<Book[]> GetReviewedBooksAsync()
        {
            await Task.Delay(1500);
            return _books;
        }

        public Task ReviewBookAsync(Book book, string review)
        {
            throw new NotImplementedException();
        }

        static int GetDamerauLevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(s, "String Cannot Be Null Or Empty");
            }

            if (string.IsNullOrEmpty(t))
            {
                throw new ArgumentNullException(t, "String Cannot Be Null Or Empty");
            }

            int n = s.Length; // length of s
            int m = t.Length; // length of t

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            int[] p = new int[n + 1]; //'previous' cost array, horizontally
            int[] d = new int[n + 1]; // cost array, horizontally

            // indexes into strings s and t
            int i; // iterates through s
            int j; // iterates through t

            for (i = 0; i <= n; i++)
            {
                p[i] = i;
            }

            for (j = 1; j <= m; j++)
            {
                char tJ = t[j - 1]; // jth character of t
                d[0] = j;

                for (i = 1; i <= n; i++)
                {
                    int cost = s[i - 1] == tJ ? 0 : 1; // cost
                                                       // minimum of cell to the left+1, to the top+1, diagonally left and up +cost                
                    d[i] = Math.Min(Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + cost);
                }

                // copy current distance counts to 'previous row' distance counts
                int[] dPlaceholder = p; //placeholder to assist in swapping p and d
                p = d;
                d = dPlaceholder;
            }

            // our last action in the above loop was to switch d and p, so p now 
            // actually has the most recent cost counts
            return p[n];
        }
    }
}
