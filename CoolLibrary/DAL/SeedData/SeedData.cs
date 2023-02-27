using CoolLibrary.Common.Entities;
using Microsoft.AspNetCore.Hosting.Server;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace CoolLibrary.DAL.SeedData
{
    public class SeedData
    {
        public static async Task Initialization(DataContext dataContext)
        {
            await chatGTP_SeedDataGenerator(dataContext);
        }

        private static async Task chatGTP_SeedDataGenerator(DataContext _dataContext)
        {
            var coverList = await ConvertImgToBase64();
            Random rand = new Random();

            List<Book> bookList = new()
            {
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Great Gatsby", Content = "The Great Gatsby is a novel by American author F. Scott Fitzgerald. Set in the summer of 1922, it follows Nick Carraway as he recounts the story of mysterious millionaire Jay Gatsby, who is obsessed with Daisy Buchanan.", Author = "F. Scott Fitzgerald", Genre = "Novel" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Novel" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Genre = "Fantasy" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Catcher in the Rye", Author = "J. D. Salinger", Genre = "Bildungsroman" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Southern Gothic" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "1984", Author = "George Orwell", Genre = "Dystopian" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Realist" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Adventures of Huckleberry Finn", Author = "Mark Twain", Genre = "Fiction" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "Animal Farm", Author = "George Orwell", Genre = "Political satire" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romantic comedy" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Lord of the Rings", Author = "J. R. R. Tolkien", Genre = "Fantasy" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Grapes of Wrath", Author = "John Steinbeck", Genre = "Social novel" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Hunger Games", Author = "Suzanne Collins", Genre = "Dystopian" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "Alice's Adventures in Wonderland", Author = "Lewis Carroll", Genre = "Fantasy" },
                new Book { Cover=coverList[rand.Next(0, coverList.Count)], Title = "The Harry Potter Series", Author = "J. K. Rowling", Genre = "Fantasy" },
            };
            bookList = AddReviews(bookList);
            bookList = AddRatings(bookList);
            bookList = AddCover(bookList);

            await _dataContext.Books.AddRangeAsync(bookList);
            await _dataContext.SaveChangesAsync();
        }

        private static List<Book> AddReviews(List<Book> books)
        {
            List<string> names = new() { "John Smith", "Alex Johnson", "Sarah Anderson", "Michael Miller", "Emily Robinson", "Daniel Carter", "Anna Harris", "Tyler Lewis", "Joseph Moore", "Rebecca King", "Matthew Walker", "Jacob White", "Jessica Allen", "Matthew Parker", "Megan Hall", "Joshua Davis", "David Martin", "James Brown", "Emily Wilson", "Andrew Taylor" };

            List<string> reviews = new List<string>
            {
                "This book was an amazing read! Highly recommend.",
                "Definitely one of the best books I've ever read!",
                "This book was really thought-provoking and I loved it.",
                "I couldn't put this book down! It was so exciting!",
                "The characters in this book were so realistic and I loved them.",
                "The plot of this book was so unique and captivating.",
                "I found this book to be incredibly inspiring.",
                "The writing was so beautiful and poetic.",
                "This book made me laugh, cry, and everything in between!",
                "This book was so educational and I learned a lot!",
                "The themes in this book were so interesting and complex.",
                "The ending of this book was so unexpected and I was amazed!",
                "I was so invested in this book, I couldn't put it down!",
                "The setting of this book was so vivid and captivating.",
                "The author had such a unique style of writing.",
                "The storyline of this book was so complex and interesting.",
                "I found this book to be so relatable and heartwarming.",
                "I was so inspired by this book and its message.",
                "This book was so eye-opening and I gained so much from it.",
                "This book was such an incredible journey and I loved it."
            };
            Random rand = new Random();

            foreach (var book in books)
            {
                var count = rand.Next(2, 10);
                for (int i = 0; i < count; i++)
                {
                    book.Reviews.Add(new Review()
                    {
                        Reviewer = names[rand.Next(1, names.Count)],
                        Message = reviews[rand.Next(1, reviews.Count)],
                    });
                }
            }

            return books;
        }

        private static List<Book> AddRatings(List<Book> books)
        {
            Random rand = new Random();

            foreach (var book in books)
            {
                var count = rand.Next(2, 10);
                for (int i = 0; i < count; i++)
                {
                    book.Ratings.Add(new Rating()
                    {
                        Score = rand.Next(2, 5),
                    });
                }
            }
            return books;
        }

        private static List<Book> AddCover(List<Book> books)
        {
            Random rand = new Random();

            foreach (var book in books)
            {
                var count = rand.Next(7000, 25500);
                book.Content = RandomTextGenerator(count);
            }
            return books;
        }

        public static string RandomTextGenerator(int length)
        {
            var CharArray = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ', ' ', ' ', '\n' };
            string text = "";
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                text += CharArray[random.Next(CharArray.Length)];
            }
            return text;
        }

        private static async Task<List<string>?> ConvertImgToBase64()
        {
            List<string> base64Img = new();

            string workingDirectory = System.AppContext.BaseDirectory;

            if (workingDirectory == null)
                return null;

            string[] files = Directory.GetFiles($@"{workingDirectory}\\Imgs");

            foreach (var file in files)
            {
                byte[] imageArray = await System.IO.File.ReadAllBytesAsync(file);

                base64Img.Add("data:image/png;base64," + Convert.ToBase64String(imageArray));
            }

            return base64Img;
        }
    }
}