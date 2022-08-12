using Microsoft.AspNetCore.Mvc;
using PhoneBook.Contact.Application.Contact.Commands.CreateContact;
using PhoneBook.Contact.Application.Contact.Commands.DeleteContact;
using PhoneBook.Contact.Application.Contact.Queries.GetContactQuery;
using PhoneBook.Contact.Application.Contact.Queries.GetContactsQuery;

namespace PhoneBook.Contact.Api.Controllers;

public class ContactController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<GetContactDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetContactDto>>> Get()
    {
        return await Mediator.Send(new GetContactsQuery());
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<ActionResult<Guid>> Create(CreateContactCommand command)
    {
        return await Mediator.Send(command);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteContactCommand(id));

        return NoContent();
    }
}