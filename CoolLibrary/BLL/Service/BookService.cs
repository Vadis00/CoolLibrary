using AutoMapper;
using CoolLibrary.BLL.Exceptions;
using CoolLibrary.BLL.Service.Abstract;
using CoolLibrary.Common.DTO;
using CoolLibrary.Common.Entities;
using CoolLibrary.DAL;
using CoolLibrary.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CoolLibrary.BLL.Service
{
    public class BookService : AbstractService
    {
        public BookService(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        public async Task<int> CreateOrUpdateAsync(NewBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            if (bookDto.Id is not null)
            {
                var bookEntity = await _dataContext.Books
                    .Where(book => book.Id == bookDto.Id)
                    .FirstOrDefaultAsync();

                if (bookEntity is null)
                    throw new NotFoundException("book");

                _dataContext.Books.Entry(bookEntity).CurrentValues.SetValues(book);
            }
            else
            {
                _dataContext.Update(book);
            }

            await _dataContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task<ICollection<BookPreviewDto>> GetAllAsync(string order)
        {
            if (order != "title" && order != "author")
                throw new InvalidAttributeException(order);

            var books = await IQueryableExtensions
                .OrderBy(_dataContext.Books, order)
                .Include(r => r.Ratings)
                .Include(r => r.Reviews)
                .ToListAsync();

            if (books == null)
                throw new NotFoundException("books");

            var booksDto = _mapper.Map<ICollection<BookPreviewDto>>(books);

            return booksDto;
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _dataContext.Books
                .Where(book => book.Id == id)
                .Include(book => book.Reviews)
                .Include(book => book.Ratings)
                .FirstOrDefaultAsync();

            if (book is null)
                throw new NotFoundException("book", id);

            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }

        public async Task DeleteByIdAsync(int id, string secretKey)
        {
            var book = await _dataContext.Books
                .Where(book => book.Id == id)
                .FirstOrDefaultAsync();

            if (book is null)
                throw new NotFoundException("book", id);

            _dataContext.Books.Remove(book);

            await _dataContext.SaveChangesAsync();
        }

        public async Task<int> AddRateAsync(RatingDto ratingDto, int id)
        {
            var book = await _dataContext.Books
                .Where(book => book.Id == id)
                .FirstOrDefaultAsync();

            if (book is null)
                throw new NotFoundException("book", id);

            var rating = _mapper.Map<Rating>(ratingDto);

            book.Ratings.Add(rating);

            _dataContext.Books.Update(book);
            await _dataContext.SaveChangesAsync();

            return rating.Id;
        }

        public async Task<int> AddReviewAsync(NewReviewDto reviewDto, int id)
        {
            var book = await _dataContext.Books
                .Where(book => book.Id == id)
                .FirstOrDefaultAsync();

            if (book is null)
                throw new NotFoundException("book", id);

            var review = _mapper.Map<Review>(reviewDto);

            book.Reviews.Add(review);

            _dataContext.Books.Update(book);
            await _dataContext.SaveChangesAsync();

            return review.Id;
        }

        public async Task<ICollection<BookPreviewDto>> GetTopRateAsync(string genre)
        {
            var bookEntity = await _dataContext.Books
                .Where(book => book.Genre == genre)
                .Include(book => book.Ratings)
                .Include(book => book.Reviews)
                .OrderByDescending(book => book.Ratings.Select(r => r.Score).DefaultIfEmpty().Average())
                .Take(10)
                .ToListAsync();

            if (bookEntity.Count() == 0)
                throw new NotFoundException("books");

            var booksDto = _mapper.Map<ICollection<BookPreviewDto>>(bookEntity);

            return booksDto;
        }
    }
}