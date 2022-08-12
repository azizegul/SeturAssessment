using MediatR;
using PhoneBook.Contact.Application.Common.Interfaces;

namespace PhoneBook.Contact.Application.Person.Commands.DeletePerson;

public record DeletePersonCommand(Guid Id) : IRequest;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Persons
            .FindAsync(new object[] { request.Id }, cancellationToken);

        entity.IsDeleted = true;
        
        _context.Persons.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}