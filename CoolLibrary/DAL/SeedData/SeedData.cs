using CoolLibrary.Common.Entities;

namespace CoolLibrary.DAL.SeedData
{
    public class SeedData
    {
        public static async Task Initialization(DataContext dataContext)
        {
            await AddBooks(dataContext);
        }
        private static async Task AddBooks(DataContext _dataContext)
        {
            var bookList = new List<Book>()
            {
                new Book()
                {
                    Title = "Code: The Hidden Language of Computer Hardware and Software",
                    Cover = "Cover",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Author = "Charles Petzold",
                    Genre = "Information Technology",
                    Ratings =
                    {
                        new Rating()
                        {
                            Score =5
                        },
                        new Rating()
                        {
                            Score =2
                        },
                        new Rating()
                        {
                            Score =1
                        },
                        new Rating()
                        {
                            Score =7
                        }
                    },
                    Reviews =
                    {
                        new Review()
                        {
                            Message="Overall, my reaction to this book is mixed",
                            Reviewer="Robert Brown"
                        },
                        new Review()
                        {
                            Message="This book provides a balanced look at the Matrix trilogy.",
                            Reviewer="Susan Clark"
                        },
                        new Review()
                        {
                            Message="I have read almost all the Matrix books & seen all the movies.",
                            Reviewer="Kenneth Walker"
                        },
                        new Review()
                        {
                            Message="It was a very easy and fast read.",
                            Reviewer="Patricia Garcia"
                        },
                        new Review()
                        {
                            Message="Very informative book and helped me gain financial literacy.",
                            Reviewer="Michael Taylor"
                        },
                        new Review()
                        {
                            Message="This a life changing book",
                            Reviewer="Susan Martin"
                        },
                        new Review()
                        {
                            Message="Great book for young people tryna become successful in today's economy. Tons of free game in this book",
                            Reviewer="Richard White"
                        },
                        new Review()
                        {
                            Message="It's a magical adventure you can't miss... You'll feel emotions as you go through this book and the next ones....",
                            Reviewer="Mark Miller"
                        },
                        new Review()
                        {
                            Message="I truly love this books one of my favorites of all time.",
                            Reviewer="Robert Brown"
                        },
                        new Review()
                        {
                            Message="I was so sad to get my book and no dust jacket and the less than what was described. The poor qualit",
                            Reviewer="Mary Jones"
                        },
                    }
                },
                new Book()
                {
                    Title = "Elon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future",
                    Cover = "Cover",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Author = "Ashlee Vance",
                    Genre = "Information Technology",
                    Ratings =
                    {
                        new Rating()
                        {
                            Score =9
                        },
                        new Rating()
                        {
                            Score =3
                        },
                        new Rating()
                        {
                            Score =6
                        },
                        new Rating()
                        {
                            Score =5
                        }
                    },
                    Reviews =
                    {
                        new Review()
                        {
                            Message="Overall, my reaction to this book is mixed",
                            Reviewer="Robert Brown"
                        },
                        new Review()
                        {
                            Message="This book provides a balanced look at the Matrix trilogy.",
                            Reviewer="Susan Clark"
                        },
                        new Review()
                        {
                            Message="I have read almost all the Matrix books & seen all the movies.",
                            Reviewer="Kenneth Walker"
                        },
                        new Review()
                        {
                            Message="It was a very easy and fast read.",
                            Reviewer="Patricia Garcia"
                        },
                        new Review()
                        {
                            Message="Very informative book and helped me gain financial literacy.",
                            Reviewer="Michael Taylor"
                        },
                        new Review()
                        {
                            Message="This a life changing book",
                            Reviewer="Susan Martin"
                        },
                        new Review()
                        {
                            Message="Great book for young people tryna become successful in today's economy. Tons of free game in this book",
                            Reviewer="Richard White"
                        },
                        new Review()
                        {
                            Message="It's a magical adventure you can't miss... You'll feel emotions as you go through this book and the next ones....",
                            Reviewer="Mark Miller"
                        },
                        new Review()
                        {
                            Message="I truly love this books one of my favorites of all time.",
                            Reviewer="Robert Brown"
                        },
                        new Review()
                        {
                            Message="I was so sad to get my book and no dust jacket and the less than what was described. The poor qualit",
                            Reviewer="Mary Jones"
                        },
                    }
                },
                new Book()
                {
                    Title = "Superintelligence: Paths, Dangers, Strategies",
                    Cover = "Cover",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Author = "Nick Bostrom",
                    Genre = "Philosophy",
                    Ratings =
                    {
                        new Rating()
                        {
                            Score =6
                        },
                        new Rating()
                        {
                            Score =10
                        },
                        new Rating()
                        {
                            Score =4
                        },
                        new Rating()
                        {
                            Score =8
                        }
                    },
                    Reviews =
                    {
                        new Review()
                        {
                            Message="Overall, my reaction to this book is mixed",
                            Reviewer="Robert Brown"
                        },
                        new Review()
                        {
                            Message="This book provides a balanced look at the Matrix trilogy.",
                            Reviewer="Susan Clark"
                        },
                        new Review()
                        {
                            Message="I have read almost all the Matrix books & seen all the movies.",
                            Reviewer="Kenneth Walker"
                        },
                        new Review()
                        {
                            Message="It was a very easy and fast read.",
                            Reviewer="Patricia Garcia"
                        },
                        new Review()
                        {
                            Message="Very informative book and helped me gain financial literacy.",
                            Reviewer="Michael Taylor"
                        },
                        new Review()
                        {
                            Message="This a life changing book",
                            Reviewer="Susan Martin"
                        },
                        new Review()
                        {
                            Message="Great book for young people tryna become successful in today's economy. Tons of free game in this book",
                            Reviewer="Richard White"
                        },
                        new Review()
                        {
                            Message="It's a magical adventure you can't miss... You'll feel emotions as you go through this book and the next ones....",
                            Reviewer="Mark Miller"
                        },
                        new Review()
                        {
                            Message="I truly love this books one of my favorites of all time.",
                            Reviewer="Robert Brown"
                        },
                        new Review()
                        {
                            Message="I was so sad to get my book and no dust jacket and the less than what was described. The poor qualit",
                            Reviewer="Mary Jones"
                        },
                    }
                },
                new Book()
                {
                    Title = "More Matrix and Philosophy: Revolutions and Reloaded Decoded",
                    Cover = "Cover",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Author = "Nick Bostrom",
                    Genre = "Philosophy",
                    Ratings =
                    {
                        new Rating()
                        {
                            Score =6
                        },
                        new Rating()
                        {
                            Score =1
                        },
                        new Rating()
                        {
                            Score =1
                        },
                        new Rating()
                        {
                            Score =3
                        }
                    },
                    Reviews =
                    {
                        new Review()
                        {
                            Message="Overall, my reaction to this book is mixed",
                            Reviewer="Robert Brown"
                        },
                        new Review()
                        {
                            Message="This book provides a balanced look at the Matrix trilogy.",
                            Reviewer="Susan Clark"
                        },
                        new Review()
                        {
                            Message="I have read almost all the Matrix books & seen all the movies.",
                            Reviewer="Kenneth Walker"
                        },
                        new Review()
                        {
                            Message="It was a very easy and fast read.",
                            Reviewer="Patricia Garcia"
                        },
                        new Review()
                        {
                            Message="Very informative book and helped me gain financial literacy.",
                            Reviewer="Michael Taylor"
                        },
                        new Review()
                        {
                            Message="This a life changing book",
                            Reviewer="Susan Martin"
                        },
                        new Review()
                        {
                            Message="Great book for young people tryna become successful in today's economy. Tons of free game in this book",
                            Reviewer="Richard White"
                        },
                        new Review()
                        {
                            Message="It's a magical adventure you can't miss... You'll feel emotions as you go through this book and the next ones....",
                            Reviewer="Mark Miller"
                        },
                        new Review()
                        {
                            Message="I truly love this books one of my favorites of all time.",
                            Reviewer="Robert Brown"
                        },
                        new Review()
                        {
                            Message="I was so sad to get my book and no dust jacket and the less than what was described. The poor qualit",
                            Reviewer="Mary Jones"
                        },
                    }
                },
            };

            await _dataContext.Books.AddRangeAsync(bookList);
            await _dataContext.SaveChangesAsync();

        }

        private static async Task AddReviews(DataContext _dataContext)
        {
            var ratingList = new List<Review>()
            {
                new Review()
                {
                    BookId=1,
                    Message="Overall, my reaction to this book is mixed",
                    Reviewer="Robert Brown"
                },
                new Review()
                {
                    BookId=1,
                    Message="This book provides a balanced look at the Matrix trilogy.",
                    Reviewer="Susan Clark"
                },
                new Review()
                {
                    BookId=1,
                    Message="I have read almost all the Matrix books & seen all the movies.",
                    Reviewer="Kenneth Walker"
                },
                new Review()
                {
                    BookId=2,
                    Message="It was a very easy and fast read.",
                    Reviewer="Patricia Garcia"
                },
                new Review()
                {
                    BookId=2,
                    Message="Very informative book and helped me gain financial literacy.",
                    Reviewer="Michael Taylor"
                },
                new Review()
                {
                    BookId=3,
                    Message="This a life changing book",
                    Reviewer="Susan Martin"
                },
                new Review()
                {
                    BookId=3,
                    Message="Great book for young people tryna become successful in today's economy. Tons of free game in this book",
                    Reviewer="Richard White"
                },
                new Review()
                {
                    BookId=4,
                    Message="It's a magical adventure you can't miss... You'll feel emotions as you go through this book and the next ones....",
                    Reviewer="Mark Miller"
                },
                new Review()
                {
                    BookId=4,
                    Message="I truly love this books one of my favorites of all time.",
                    Reviewer="Robert Brown"
                },
                new Review()
                {
                    BookId=4,
                    Message="I was so sad to get my book and no dust jacket and the less than what was described. The poor qualit",
                    Reviewer="Mary Jones"
                },
            };

            await _dataContext.Reviews.AddRangeAsync(ratingList);

            await _dataContext.SaveChangesAsync();
        }

        private static async Task AddRatings(DataContext _dataContext)
        {
            var ratingList = new List<Book>()
            {
            };

            await _dataContext.Books.AddRangeAsync(ratingList);

            await _dataContext.SaveChangesAsync();
        }
    }
}