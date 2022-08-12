using Microsoft.AspNetCore.Mvc;
using PhoneBook.Contact.Application.Person.Commands.CreatePerson;
using PhoneBook.Contact.Application.Person.Commands.DeletePerson;
using PhoneBook.Contact.Application.Person.Queries.GetPersonQuery;
using PhoneBook.Contact.Application.Person.Queries.GetPersonsQuery;

namespace PhoneBook.Contact.Api.Controllers;

public class PersonController : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<ActionResult<Guid>> Create(CreatePersonCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetPersonsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetPersonsDto>>> Get()
    {
        return await Mediator.Send(new GetPersonsQuery());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetPersonDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetPersonDto>> GetPerson()
    {
        return await Mediator.Send(new GetPersonQuery());
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeletePersonCommand(id));

        return NoContent();
    }
}