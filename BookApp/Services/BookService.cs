using BookApp.Models;
using System;
using System.Collections.ObjectModel;
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
                Description = "The “work from home” phenomenon is thoroughly explored in this illuminating new book from bestselling 37signals founders Fried and Hansson, who point to the surging trend of employees working from home (and anywhere else) and explain the challenges and unexpected benefits.  Most important, they show why – with a few controversial exceptions such as Yahoo -- more businesses will want to promote this new model of getting things done.",
                CoverImageUrl = "http://ecx.images-amazon.com/images/I/41KQs2jNyaL._SY344_BO1,204,203,200_.jpg",
                Rating = 4,
                ReviewCount = 2871,
                WebUrl = "https://www.goodreads.com/book/show/17316682-remote"
            },
            new Book
            {
                Title = "Papillion",
                Author = "Henri Charrière",
                Description = "Papillon (fiðrildið) var ungur dæmdur í ævilanga þrælkun. Átta sinnum strauk hann og sigldi þúsundir kílómetra á opnum báti. Hann náðist alltaf og var að lokum sendur til Djöflaeyjarinnar sem er alræmdur kvalastaður og pestarbæli. Þaðan hafði engum tekist að sleppa. Jón O. Edwald íslenskaði.",
                CoverImageUrl = "http://frixos.files.wordpress.com/2009/04/papillon_book.jpg",
                Rating = 3.5f,
                ReviewCount = 87,
                WebUrl = "https://www.goodreads.com/book/show/55290311-papillion"
            },
            new Book
            {
                Title = "The Dark Tower: The Gunslinger",
                Author = "Stephen King",
                Description = "'The man in black fled across the desert, and the gunslinger followed.' With those words, millions of readers were introduced to Stephen King's Roland ' an implacable gunslinger in search of the enigmatic Dark Tower, powering his way through a dangerous land filled with ancient technology and deadly magic. Now, in a comic book personally overseen by King himself, Roland's past is revealed! Sumptuously drawn by Jae Lee and Richard Isanove, adapted by long-time Stephen King expert, Robin Furth (author of Stephen King's The Dark Tower: A Concordance), and scripted by New York Times Bestseller Peter David, this series delves in depth into Roland's origins ' the perfect introduction to this incredibly realized world; while long-time fans will thrill to adventures merely hinted at in the novels. Be there for the very beginning of a modern classic of fantasy literature!",
                CoverImageUrl = "http://3.bp.blogspot.com/-ASeA6F81WTY/UTeQmRhyaNI/AAAAAAAAAUU/VDzSPwV99o4/s1600/the-dark-tower-gunslinger-bk-i-9781444723441.jpg",
                Rating = 4.5f,
                ReviewCount = 1074,
                WebUrl = "https://www.goodreads.com/book/show/342445.The_Dark_Tower"
            },
            new Book
            {
                Title = "Artemis Fowl",
                Author = "Eoin Colfer",
                Description = "Twelve-year-old Artemis Fowl is a millionaire, a genius, and above all, a criminal mastermind. But even Artemis doesn't know what he's taken on when he kidnaps a fairy, Captain Holly Short of the LEPrecon Unit. These aren't the fairies of bedtime stories—they're dangerous! Full of unexpected twists and turns, Artemis Fowl is a riveting, magical adventure.",
                CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1477286232l/32733787.jpg",
                Rating = 5,
                ReviewCount = 50143,
                WebUrl = "https://www.goodreads.com/book/show/249747.Artemis_Fowl"
            },
            new Book
            {
                Title = "Sideways Arithmetic From Wayside School",
                Author = "Louis Sachar",
                Description = "Why does elf + elf = fool? How many meals will Miss Mush, the lunch teacher, have to cook for the food to taste as bad as it smells? This book is packed full of brain teasers and maths puzzles and all the wacky pupils from Wayside School to help you find the logical solutions to all the problems.",
                CoverImageUrl = "https://th.bing.com/th/id/OIP.qviz9HsX4Igzz0d-SHqqpAHaKv?pid=Api&w=124&h=180&c=7",
                Rating = 4.5f,
                ReviewCount = 4104,
                WebUrl = "https://www.goodreads.com/book/show/15782.Sideways_Arithmetic_from_Wayside_School"
            },
            new Book
            {
                Title = "Pet Sematary",
                Author = "Stephen King",
                Description = "The road in front of Dr. Louis Creed's rural Maine home frequently claims the lives of neighborhood pets. Louis has recently moved from Chicago to Ludlow with his wife Rachel, their children and pet cat. Near their house, local children have created a cemetery for the dogs and cats killed by the steady stream of transports on the busy highway. Deeper in the woods lies another graveyard, an ancient Indian burial ground whose sinister properties Louis discovers when the family cat is killed.",
                CoverImageUrl = "https://i1.wp.com/dajjeh.com/wp-content/uploads/2018/07/pet-sematary-565x1024.jpg?fit=565%2C1024&ssl=1",
                Rating = 4.68f,
                ReviewCount = 2464,
                WebUrl = "https://stephenking.com/works/novel/pet-sematary.html"
            }
        };

        ObservableCollection<Book> _reviewedBooks = new ObservableCollection<Book>();


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

        public async Task<ObservableCollection<Book>> GetReviewedBooksAsync()
        {
            await Task.Delay(1500);
            return _reviewedBooks;
        }

        public async Task ReviewBookAsync(Book book, float rating)
        {
            await Task.Delay(1500);
            book.Rating = rating;
            _reviewedBooks.Add(book);
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
