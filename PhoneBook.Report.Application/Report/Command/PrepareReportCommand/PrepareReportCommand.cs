using Flurl.Http;
using MediatR;
using MongoDB.Driver;
using PhoneBook.Contact.Domain.Enums;
using PhoneBook.Report.Application.Common.Interfaces;
using PhoneBook.Report.Domain.Entities;
using PhoneBook.Report.Domain.Enums;

namespace PhoneBook.Report.Application.Report.Command.PrepareReportCommand;

public class PrepareReportCommand : IRequest<Unit>
{
    public string ReportId { get; set; }
}

public class PrepareReportCommandHandler : IRequestHandler<PrepareReportCommand, Unit>
{
    private readonly IApplicationDbContext _context;
    private string baseUrl = "https://localhost:7236/Contact";

    public PrepareReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PrepareReportCommand request, CancellationToken cancellationToken)
    {
        var data = await baseUrl.GetJsonAsync<IList<ContactsDto>>(cancellationToken);
        
        var reportData = data
            .Where(k => k.InfoType == ContactInfoType.Location)
            .GroupBy(k => k.Info)
            .Select(k => new ReportData
            {
                Location = k.Key,
            }).ToList();

        foreach (var reportItem in reportData)
        {
            var personIdList = data.Where(y => y.InfoType == ContactInfoType.Location && y.Info == reportItem.Location)
                .Select(x => x.PersonId).ToList();

            reportItem.RegisteredPersonCount = personIdList.Count;
            reportItem.RegisteredPersonPhoneCount = data.Count(x =>
                personIdList.Contains(x.PersonId) && x.InfoType == ContactInfoType.Phone);
        }

        var report = await _context.Report.Find(x => x.Id == request.ReportId).FirstOrDefaultAsync(cancellationToken);
        report.Data = reportData;
        report.Status = ReportStatus.Completed;

        await _context.Report.ReplaceOneAsync(k => k.Id == request.ReportId, report,
            cancellationToken: cancellationToken);

        return Unit.Value;
    }
}