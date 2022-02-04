using BookStore.Data;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET api/Books
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }
        // GET api/Books/<id>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookByIDAsync(id);
            if (book==null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        //Post api/Books
        [HttpPost("")]
        public async Task<IActionResult> AddBookAsync([FromBody]BooksModel booksModel)
        {
            var id = await _bookRepository.AddBookAsync(booksModel);
            return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "books" },id);

        }
        //Put api/Books/<id>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute]int id,[FromBody]BooksModel booksModel)
        {
            await _bookRepository.UpdateBookAsync(id, booksModel);
            return Ok();

        }
        //Patch api/Books/<id>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePropertiesAsync([FromRoute]int id,[FromBody]JsonPatchDocument booksModel)
        {
            await _bookRepository.UpdatePropertiesAsync(id, booksModel);
            return Ok();
        }
        //Delete api/Books/<id>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
