using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BooksRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(BookStoreContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BooksModel>> GetAllBooksAsync()
        {
            var books = await _context.BookStores.ToListAsync();
            return _mapper.Map<List<BooksModel>>(books);
        }

        public async Task<BooksModel> GetBookByIDAsync(int id)
        {
            var book = await _context.BookStores.FindAsync(id);
            return _mapper.Map<BooksModel>(book);
        }

        public async Task<int> AddBookAsync(BooksModel booksModel)
        {
            var book = _mapper.Map<BooksModel>(booksModel);
            _context.BookStores.Add(book);
            await _context.SaveChangesAsync();
            return book.ID;
        }

        public async Task UpdateBookAsync(int bookId , BooksModel booksModel)
        {
            var book = new BooksModel()
            {
                ID = bookId,
                Name = booksModel.Name,
                Description = booksModel.Description,
                price = booksModel.price,
                PublishedOn = booksModel.PublishedOn,
                Pages = booksModel.Pages,
                Rating = booksModel.Rating
            };
            _context.BookStores.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePropertiesAsync(int bookid , JsonPatchDocument bookmodel)
        {
            var book = await _context.BookStores.FindAsync(bookid);
            if (book != null)
            {
                bookmodel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookid)
        {
            var Book = new BooksModel()
            {
                ID = bookid
            };
            _context.BookStores.Remove(Book);
            await _context.SaveChangesAsync();
        }
        
    }
}
