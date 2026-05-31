using LibraryManagementAPI.Models;
using LibraryManagementAPI.Models.DTOs;
using LibraryManagementAPI.Repositories;
using LibraryManagementAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllContacts()
    {
        try
        {
            var contacts = await _contactRepository.GetAllContacts();
            return Ok(ApiResponse<IEnumerable<Contact>>.SuccessResponse(contacts, "Contacts retrieved successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<IEnumerable<Contact>>.FailureResponse(ex.Message));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(int id)
    {
        try
        {
            var contact = await _contactRepository.GetContactById(id);
            return Ok(ApiResponse<Contact>.SuccessResponse(contact, "Contact retrieved successfully"));
        }
        catch (Exception ex)
        {
            return NotFound(ApiResponse<Contact>.FailureResponse(ex.Message));
        }
    }

    [HttpGet("network/{networkProvider}")]
    public async Task<IActionResult> GetContactsByNetworkProvider(NetworkProvider networkProvider)
    {
        try
        {
            var contacts = await _contactRepository.GetContactsByProvider(networkProvider);
            return Ok(ApiResponse<IEnumerable<Contact>>.SuccessResponse(contacts, $"{networkProvider} contacts retrieved successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<IEnumerable<Contact>>.FailureResponse(ex.Message));
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
        try
        {
            var contact = await _contactRepository.CreateContact(createContactDto);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id },
                ApiResponse<Contact>.SuccessResponse(contact, "Contact created successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<Contact>.FailureResponse(ex.Message));
        }
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateContact(int id, CreateContactDto createContactDto)
    {
        try
        {
            var contact = await _contactRepository.UpdateContact(id, createContactDto);
            return Ok(ApiResponse<Contact>.SuccessResponse(contact, "Contact updated successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<Contact>.FailureResponse(ex.Message));
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        try
        {
            await _contactRepository.DeleteContact(id);
            return Ok(ApiResponse<string>.SuccessResponse("Contact deleted successfully"));
        }
        catch (Exception ex)
        {
            return NotFound(ApiResponse<string>.FailureResponse(ex.Message));
        }
    }
}