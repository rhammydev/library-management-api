using LibraryManagementAPI.Models;
using LibraryManagementAPI.Models.DTOs;

namespace LibraryManagementAPI.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllContacts();
    
    Task<Contact> GetContactById(int id);
    
    Task<Contact> CreateContact(CreateContactDto createContactDto);
    
    Task<Contact> UpdateContact(int id, CreateContactDto createContactDto);
    
    Task<bool> DeleteContact(int id);
    
    Task<IEnumerable<Contact>> GetContactsByProvider(NetworkProvider networkProvider);
}