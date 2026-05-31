using LibraryManagementAPI.Models;
using LibraryManagementAPI.Models.DTOs;

namespace LibraryManagementAPI.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooks();
    
    Task<Book> GetBookById(int id);
    
    Task<Book> CreateBook(CreateBookDto createBookDto);
    
    Task<Book> UpdateBook(int id, CreateBookDto createBookDto);
    
    Task<bool> DeleteBook(int id);
    
    Task<IEnumerable<Book>> SearchBooks(string searchString);
    
    Task<IEnumerable<Book>> GetBooksByCategory(string category);
    
    Task<IEnumerable<Book>> GetOutOfStockBooks();
}