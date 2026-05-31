using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    
    // saving table to the DB
    public DbSet<Book> Books { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .Property(c => c.NetworkProvider)
            .HasConversion<string>(); // ← saves as "MTN", "Airtel", "Glo", "Etisalat"
        
  /*   modelBuilder.Entity<Book>().HasData(
        new Book
        {
            Id = 11,
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Category = "Programming",
            Price = 15000,
            Quantity = 10,
            CreatedAt = new DateTime(2025, 1, 1)
        },
        new Book
        {
            Id = 12,
            Title = "The Pragmatic Programmer",
            Author = "Andrew Hunt",
            Category = "Programming",
            Price = 18000,
            Quantity = 8,
            CreatedAt = new DateTime(2025, 1, 2)
        },
        new Book
        {
            Id = 13,
            Title = "Atomic Habits",
            Author = "James Clear",
            Category = "Self Development",
            Price = 12000,
            Quantity = 15,
            CreatedAt = new DateTime(2025, 1, 3)
        },
        new Book
        {
            Id = 14,
            Title = "Think and Grow Rich",
            Author = "Napoleon Hill",
            Category = "Business",
            Price = 10000,
            Quantity = 12,
            CreatedAt = new DateTime(2025, 1, 4)
        },
        new Book
        {
            Id = 15,
            Title = "Rich Dad Poor Dad",
            Author = "Robert Kiyosaki",
            Category = "Finance",
            Price = 9500,
            Quantity = 20,
            CreatedAt = new DateTime(2025, 1, 5)
        },
        new Book
        {
            Id = 16,
            Title = "The Alchemist",
            Author = "Paulo Coelho",
            Category = "Fiction",
            Price = 8500,
            Quantity = 7,
            CreatedAt = new DateTime(2025, 1, 6)
        },
        new Book
        {
            Id = 17,
            Title = "Introduction to Algorithms",
            Author = "Thomas H. Cormen",
            Category = "Programming",
            Price = 25000,
            Quantity = 5,
            CreatedAt = new DateTime(2025, 1, 7)
        },
        new Book
        {
            Id = 18,
            Title = "Deep Work",
            Author = "Cal Newport",
            Category = "Productivity",
            Price = 11000,
            Quantity = 18,
            CreatedAt = new DateTime(2025, 1, 8)
        },
        new Book
        {
            Id = 19,
            Title = "The Psychology of Money",
            Author = "Morgan Housel",
            Category = "Finance",
            Price = 13000,
            Quantity = 25,
            CreatedAt = new DateTime(2025, 1, 9)
        },
        new Book
        {
            Id = 20,
            Title = "Zero to One",
            Author = "Peter Thiel",
            Category = "Business",
            Price = 14000,
            Quantity = 9,
            CreatedAt = new DateTime(2025, 1, 10)
        }
    );
     
     modelBuilder.Entity<Contact>().HasData(
    new Contact
    {
        Id = 1,
        Name = "Emeka Okafor",
        PhoneNumber = "08031234567",
        NetworkProvider = NetworkProvider.MTN,
        CreatedAt = new DateTime(2025, 1, 5)
    },
    new Contact
    {
        Id = 2,
        Name = "Ngozi Adeyemi",
        PhoneNumber = "08061234567",
        NetworkProvider = NetworkProvider.MTN,
        CreatedAt = new DateTime(2025, 1, 8)
    },
    new Contact
    {
        Id = 3,
        Name = "Chukwudi Eze",
        PhoneNumber = "08101234567",
        NetworkProvider = NetworkProvider.MTN,
        CreatedAt = new DateTime(2025, 2, 3)
    },
    new Contact
    {
        Id = 4,
        Name = "Amaka Okonkwo",
        PhoneNumber = "08131234567",
        NetworkProvider = NetworkProvider.MTN,
        CreatedAt = new DateTime(2025, 2, 14)
    },
    new Contact
    {
        Id = 16,
        Name = "Tunde Bakare",
        PhoneNumber = "08021234567",
        NetworkProvider = NetworkProvider.Airtel,
        CreatedAt = new DateTime(2025, 3, 1)
    },
    new Contact
    {
        Id = 6,
        Name = "Funke Adeleke",
        PhoneNumber = "08081234567",
        NetworkProvider = NetworkProvider.Airtel,
        CreatedAt = new DateTime(2025, 3, 20)
    },
    new Contact
    {
        Id = 7,
        Name = "Seun Adesanya",
        PhoneNumber = "07011234567",
        NetworkProvider = NetworkProvider.Airtel,
        CreatedAt = new DateTime(2025, 4, 7)
    },
    new Contact
    {
        Id = 8,
        Name = "Biodun Fashola",
        PhoneNumber = "08121234567",
        NetworkProvider = NetworkProvider.Airtel,
        CreatedAt = new DateTime(2025, 4, 19)
    },
    new Contact
    {
        Id = 9,
        Name = "Chioma Nwosu",
        PhoneNumber = "08051234567",
        NetworkProvider = NetworkProvider.Glo,
        CreatedAt = new DateTime(2025, 5, 2)
    },
    new Contact
    {
        Id = 10,
        Name = "Yusuf Abdullahi",
        PhoneNumber = "08071234567",
        NetworkProvider = NetworkProvider.Glo,
        CreatedAt = new DateTime(2025, 5, 18)
    },
    new Contact
    {
        Id = 11,
        Name = "Fatima Bello",
        PhoneNumber = "08111234567",
        NetworkProvider = NetworkProvider.Glo,
        CreatedAt = new DateTime(2025, 6, 6)
    },
    new Contact
    {
        Id = 12,
        Name = "Musa Ibrahim",
        PhoneNumber = "08151234567",
        NetworkProvider = NetworkProvider.Glo,
        CreatedAt = new DateTime(2025, 6, 25)
    },
    new Contact
    {
        Id = 13,
        Name = "Sola Ogundipe",
        PhoneNumber = "08091234567",
        NetworkProvider = NetworkProvider.Etisalat,
        CreatedAt = new DateTime(2025, 7, 10)
    },
    new Contact
    {
        Id = 14,
        Name = "Kemi Adeola",
        PhoneNumber = "08171234567",
        NetworkProvider = NetworkProvider.Etisalat,
        CreatedAt = new DateTime(2025, 7, 22)
    },
    new Contact
    {
        Id = 15,
        Name = "Dare Olusanya",
        PhoneNumber = "08181234567",
        NetworkProvider = NetworkProvider.Etisalat,
        CreatedAt = new DateTime(2025, 8, 3)
    }
); */
    }
}