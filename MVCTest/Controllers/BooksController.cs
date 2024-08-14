using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCTest.Models;
using MVCTest.Services;

namespace MVCTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksServices;

        public BooksController(BooksService booksService)
        {
            _booksServices = booksService;
        }

        [HttpGet]
        public async Task<List<Book>> Get()
            => await _booksServices.GetAsync();

        [HttpGet("{Id:length(24)}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            //use var on real project
            Book? book = await _booksServices.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book newBook)
        {
            await _booksServices.CreateAsync(newBook);
            return CreatedAtAction(
                nameof(Get),
                new { id = newBook.Id },
                newBook
            );
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Book updatedBook)
        {
            Book? book = await _booksServices.GetAsync(id); 
            
            if (book is null)
            {
                return NotFound();
            }
            updatedBook.Id = book.Id;
            await _booksServices.UpdateAsync(id, updatedBook);

            return NoContent();

        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            Book? book = await _booksServices.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }

            await _booksServices.RemoveAsync(id);
            return NoContent();
        }
    }
}
