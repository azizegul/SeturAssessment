using MediatR;
using MongoDB.Driver;
using PhoneBook.Report.Application.Common.Interfaces;

namespace PhoneBook.Report.Application.Report.Queries.GetReportQuery;

public record GetReportQuery(string Id) : IRequest<ReportDto>;

public class GetReportQueryHandler : IRequestHandler<GetReportQuery, ReportDto>
{
    private readonly IApplicationDbContext _context;

    public GetReportQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ReportDto> Handle(GetReportQuery request, CancellationToken cancellationToken)
    {
        var report =
            await _context
                .Report.Find(x => x.IsDeleted == false && x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
        
        if (report == null)
            return null;
        
        var reportDto = new ReportDto
        {
            Id = report.Id,
            RequestDate = report.RequestDate,
            Status = report.Status,
            Data = report.Data?.Select(x=> new ReportDataDto
            {
                Location = x.Location,
                RegisteredPersonCount = x.RegisteredPersonCount,
                RegisteredPersonPhoneCount = x.RegisteredPersonPhoneCount
            }).ToList()
        };

        return reportDto;
    }
}