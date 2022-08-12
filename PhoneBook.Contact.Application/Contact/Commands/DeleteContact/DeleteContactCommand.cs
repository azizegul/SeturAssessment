using MediatR;
using PhoneBook.Contact.Application.Common.Interfaces;

namespace PhoneBook.Contact.Application.Contact.Commands.DeleteContact;

public record DeleteContactCommand(Guid Id) : IRequest;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contacts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        entity.IsDeleted = true;
        _context.Contacts.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}