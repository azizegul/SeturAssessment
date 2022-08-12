using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Contact.Application.Common.Interfaces;
using PhoneBook.Contact.Application.Contact.Queries.GetContactQuery;

namespace PhoneBook.Contact.Application.Person.Queries.GetPersonQuery;

public record GetPersonQuery : IRequest<GetPersonDto>
{
}

public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, GetPersonDto>
{
    private readonly IApplicationDbContext _context;

    public GetPersonQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetPersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .Include(x => x.Contacts)
            .Where(x => x.IsDeleted == false)
            .Select(x => new GetPersonDto()
            {
                Name = x.Name,
                Surname = x.Surname,
                Company = x.Company,
                Contacts = x.Contacts
                    .Select(x => new GetContactDto()
                    {
                        PersonId = x.PersonId,
                        Info = x.Info,
                        InfoType = x.InfoType,
                    }).ToList()
            }).FirstOrDefaultAsync(cancellationToken);
    }
}