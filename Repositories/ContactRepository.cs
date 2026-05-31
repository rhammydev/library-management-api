using LibraryManagementAPI.Data;
using LibraryManagementAPI.Helpers;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ContactRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Contact>> GetAllContacts()
    {
        var contacts = await _dbContext.Contacts.ToListAsync();
        return contacts;
    }

    public async Task<Contact> GetContactById(int id)
    {
        var contact = await _dbContext.Contacts.FindAsync(id);
        return contact ?? throw new Exception($"Contact with id: {id} not found");
    }

    public async Task<Contact> CreateContact(CreateContactDto createContactDto)
    {
        var contactExists = await _dbContext.Contacts.AnyAsync(c => c.PhoneNumber == createContactDto.PhoneNumber);
        if (contactExists)
        {
            throw new Exception($"Contact with number: {createContactDto.PhoneNumber} already exists");
        }
        
        // get network provider
        var networkProvider = NetworkProviderResolver.DetectNetworkProvider(createContactDto.PhoneNumber);
        if (networkProvider == null)
        {
            throw new Exception($"Phone number: {createContactDto.PhoneNumber} is not a recognised Nigerian network");
        }

        var contact = new Contact
        {
            PhoneNumber = createContactDto.PhoneNumber,
            Name = createContactDto.Name,
            NetworkProvider = networkProvider.Value
        };
        await _dbContext.Contacts.AddAsync(contact);
        await _dbContext.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> UpdateContact(int id, CreateContactDto createContactDto)
    {
        var existingContact = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        if (existingContact == null)
        {
            throw new Exception("Contact not found");
        }
        
        var contactExists = await _dbContext.Contacts.AnyAsync(x => 
            x.PhoneNumber == createContactDto.PhoneNumber && x.Id != id);
        if (contactExists)
        {
            throw new Exception("A contact with this phone number already exists");
        }
        
        var networkProvider = NetworkProviderResolver.DetectNetworkProvider(createContactDto.PhoneNumber);
        if (networkProvider == null)
        {
            throw new Exception($"Phone number: {createContactDto.PhoneNumber} is not a recognised Nigerian network");
        }
        existingContact.Name = createContactDto.Name;
        existingContact.PhoneNumber = createContactDto.PhoneNumber;
        existingContact.NetworkProvider = networkProvider.Value;
        
        await _dbContext.SaveChangesAsync();
        return existingContact;
    }

    public async Task<bool> DeleteContact(int id)
    {
        var contactExists = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        if (contactExists == null)
        {
            throw new Exception($"Contact with id: {id} not found"); 
        }
        _dbContext.Contacts.Remove(contactExists);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Contact>> GetContactsByProvider(NetworkProvider networkProvider)
    {
        var contacts = await _dbContext.Contacts
            .Where(c => c.NetworkProvider == networkProvider)
            .ToListAsync();
        return contacts;
    }
}