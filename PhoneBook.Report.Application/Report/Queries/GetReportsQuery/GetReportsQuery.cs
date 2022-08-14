using MediatR;
using MongoDB.Driver;
using PhoneBook.Report.Application.Common.Interfaces;

namespace PhoneBook.Report.Application.Report.Queries.GetReportsQuery;

public record GetReportsQuery : IRequest<List<ReportsDto>>
{
}

public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, List<ReportsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetReportsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReportsDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
    {
        var reportQuery =
            await _context.Report.Find(k => k.IsDeleted == false).ToListAsync(cancellationToken);

        return reportQuery.Select(k => new ReportsDto
        {
            Id = k.Id,
            RequestDate = k.RequestDate,
            Status = k.Status
        }).ToList();
    }
}