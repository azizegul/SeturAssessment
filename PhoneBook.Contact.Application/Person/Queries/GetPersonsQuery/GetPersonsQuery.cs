using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Contact.Application.Common.Interfaces;

namespace PhoneBook.Contact.Application.Person.Queries.GetPersonsQuery;

public record GetPersonsQuery : IRequest<List<GetPersonsDto>>
{
  
}

public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery,List<GetPersonsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPersonsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetPersonsDto>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .Where(x => x.IsDeleted == false)
            .Select(x => new GetPersonsDto
            {
                Name = x.Name,
                Surname = x.Surname,
                Company = x.Company
            }).ToListAsync(cancellationToken);
    }
}