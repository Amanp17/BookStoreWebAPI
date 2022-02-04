using BookStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IBookRepository 
    {
        Task<List<BooksModel>> GetAllBooksAsync();
        Task<BooksModel> GetBookByIDAsync(int id);
        Task<int> AddBookAsync(BooksModel booksModel);
        Task UpdateBookAsync(int bookId, BooksModel booksModel);
        Task UpdatePropertiesAsync(int bookid, JsonPatchDocument bookmodel);
        Task DeleteBookAsync(int bookid);
    }
}
