using MassTransit;
using MediatR;
using PhoneBook.Report.Application.Common.Interfaces;
using PhoneBook.Report.Domain.Entities;
using PhoneBook.Report.Domain.Enums;
using PhoneBook.Report.Domain.Events;

namespace PhoneBook.Report.Application.Report.Command.CreateReport;

public record CreateReportCommand : IRequest<string>
{
}

public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateReportCommandHandler(IApplicationDbContext context, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<string> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Report
        {
            RequestDate = DateTime.Now,
            Status = ReportStatus.Preparing
        };

        await _context.Report.InsertOneAsync(entity, null, cancellationToken);

        await _publishEndpoint.Publish<ReportCreated>(new(entity.Id), cancellationToken);

        return entity.Id;
    }
}