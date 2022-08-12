using MediatR;
using PhoneBook.Contact.Application.Common.Interfaces;
using PhoneBook.Contact.Domain.Enums;

namespace PhoneBook.Contact.Application.Contact.Commands.CreateContact;

public record CreateContactCommand : IRequest<Guid>
{
    public Guid PersonId { get; set; }
    public ContactInfoType InfoType { get; set; }
    public string Info { get; set; }
}

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Contact
        {
            PersonId = request.PersonId,
            InfoType = request.InfoType,
            Info = request.Info
        };

        _context.Contacts.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}