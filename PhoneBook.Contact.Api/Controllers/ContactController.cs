using Microsoft.AspNetCore.Mvc;
using PhoneBook.Contact.Application.Contact.Commands.CreateContact;
using PhoneBook.Contact.Application.Contact.Commands.DeleteContact;
using PhoneBook.Contact.Application.Contact.Queries.GetContactQuery;
using PhoneBook.Contact.Application.Contact.Queries.GetContactsQuery;

namespace PhoneBook.Contact.Api.Controllers;

public class ContactController : ApiControllerBase
{
    /// <summary>
    /// Get all contacts.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetContactDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetContactDto>>> Get()
    {
        return await Mediator.Send(new GetContactsQuery());
    }
    
    /// <summary>
    /// Create new contact.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<ActionResult<Guid>> Create(CreateContactCommand command)
    {
        return await Mediator.Send(command);
    }
    
    /// <summary>
    /// Delete existing contact.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteContactCommand(id));

        return NoContent();
    }
}