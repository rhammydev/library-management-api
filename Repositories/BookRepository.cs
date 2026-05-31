using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        var books = await _dbContext.Books.ToListAsync();
        return  books;
    }

    public async Task<Book> GetBookById(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        return book ?? throw new Exception("Book not found");
    }

    public async Task<Book> CreateBook(CreateBookDto createBookDto)
    {
        var bookExist = await _dbContext.Books.AnyAsync(x => 
            x.Title == createBookDto.Title 
            && x.Author == createBookDto.Author);
        if (bookExist)
        {
            throw new Exception("Book already exists");
        }
        
        var book = new Book
        {
            Title = createBookDto.Title,
            Author = createBookDto.Author,
            Category = createBookDto.Category,
            Price = createBookDto.Price,
            Quantity = createBookDto.Quantity
        };
        
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
        return book;

    }

    public async Task<Book> UpdateBook(int id, CreateBookDto createBookDto)
    {
        var existingBook = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (existingBook == null)
        {
            throw new Exception("Book not found");
        }
        
        // Exclude the current book from the duplicate check
        var bookExist = await _dbContext.Books.AnyAsync(x => 
            x.Title == createBookDto.Title && 
            x.Author == createBookDto.Author &&
            x.Id != id); 
        
        if (bookExist)
        {
            throw new Exception("A book with the same title and author already exists");
        }
        
        existingBook.Title = createBookDto.Title;
        existingBook.Author = createBookDto.Author;
        existingBook.Category = createBookDto.Category;
        existingBook.Price = createBookDto.Price;
        existingBook.Quantity = createBookDto.Quantity;
        
        await _dbContext.SaveChangesAsync();
        return existingBook;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book == null)
        {
            throw new Exception("Book not found");
        }
        
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Book>> SearchBooks(string searchString)
    {
        var  books = await _dbContext.Books.Where(x => 
            x.Title.ToLower().Contains(searchString))
            .ToListAsync();
        if (books.Count == 0)
        {
            throw new Exception("Book not found");
        }
        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByCategory(string category)
    {
        var  books = await _dbContext.Books.Where(x => 
            x.Category.ToLower() == category.ToLower())
            .ToListAsync();

        if (books.Count == 0)
        {
            throw new Exception("Book not found");
        }
        return books;
    }

    public async Task<IEnumerable<Book>> GetOutOfStockBooks()
    {
        var books = await _dbContext.Books.Where(x => 
            x.Quantity == 0).ToListAsync();
        if (books.Count == 0)
        {
            throw new Exception("Book not found");
        }
        return books;
    }
}