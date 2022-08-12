using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Contact.Application.Common.Interfaces;
using PhoneBook.Contact.Application.Contact.Queries.GetContactQuery;

namespace PhoneBook.Contact.Application.Contact.Queries.GetContactsQuery;

public record GetContactsQuery : IRequest<List<GetContactDto>>
{
}

public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<GetContactDto>>
{
    private readonly IApplicationDbContext _context;

    public GetContactsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contacts
            .Where(x => x.IsDeleted == false)
            .Select(x => new GetContactDto()
            {
                PersonId = x.PersonId,
                Info = x.Info,
                InfoType = x.InfoType,
            }).ToListAsync(cancellationToken);
    }
}