using LibraryManagementAPI.Models;
using LibraryManagementAPI.Models.DTOs;
using LibraryManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    
     private readonly IBookRepository _bookRepository;
     
     public  BookController(IBookRepository bookRepository)
     {
         _bookRepository = bookRepository;
     }
     
     // Get all books
     [HttpGet("get-all-books")]
     public async Task<IActionResult> GetBooks()
     {
         var books = await _bookRepository.GetAllBooks();
         return Ok(books);
     }
     
     // Get a book by ID
     [HttpGet("get-book-by-id/{id}")]
     public async Task<IActionResult> GetBookById(int id)
     {
         var book = await _bookRepository.GetBookById(id);
         return Ok(book);
     }
     
     // get books by category
     [HttpGet("get-book-by-category/{category}")]
     public async Task<IActionResult> GetBooksByCategory(string category)
     {
         var  books = await _bookRepository.GetBooksByCategory(category);
         return Ok(books);
     }
     
     // search books
     [HttpGet("search-books")]
     public async Task<IActionResult> SearchBooks(string searchString)
     {
         var books = await _bookRepository.SearchBooks(searchString);
         return Ok(books);
     }
     
     // create a book
     [HttpPost("create-book")]
     public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
     {
         var book = await _bookRepository.CreateBook(createBookDto);
         return Ok(book);
     }
     
     // update a book
     [HttpPut("update-book/{id}")]
     public async Task<IActionResult> UpdateBook(int id, CreateBookDto createBookDto)
     {
         var  updatedBook = await _bookRepository.UpdateBook(id, createBookDto);
         return Ok(updatedBook);
     }
     
     // Delete a book
     [HttpDelete("delete-book/{id}")]
     public async Task<IActionResult> DeleteBook(int id)
     {
         var isDeleted = await _bookRepository.DeleteBook(id);
         return Ok(isDeleted);
     }
     
     // Get out of stock books
     [HttpGet("get-out-of-stock-books")]
     public async Task<IActionResult> GetOutOfStockBooks()
     {
        var   books = await _bookRepository.GetOutOfStockBooks();
         return Ok(books); 
     }

}