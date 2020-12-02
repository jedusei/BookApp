using BookApp.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class ReviewThanksViewModel : BaseViewModel
    {
        public Book[] Suggestions { get; } = new Book[] {
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
        public ICommand AddFriendsCommand { get; private set; }

        public ReviewThanksViewModel()
        {
        }
    }
}
