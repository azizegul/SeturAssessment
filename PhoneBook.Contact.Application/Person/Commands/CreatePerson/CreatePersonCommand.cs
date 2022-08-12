using MediatR;
using PhoneBook.Contact.Application.Common.Interfaces;
using PhoneBook.Contact.Domain.Entities;

namespace PhoneBook.Contact.Application.Person.Commands.CreatePerson;

public record CreatePersonCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Company { get; set; }
    
}

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Person
        {
            Name = request.Name,
            Surname = request.Surname,
            Company = request.Company,
        };

        _context.Persons.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}