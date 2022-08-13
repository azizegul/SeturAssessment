using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using PhoneBook.Report.Application.Report.Command.PrepareReportCommand;
using PhoneBook.Report.Domain.Events;

namespace PhoneBook.Report.Application.EventHandlers;

public class PrepareReportWhenReportCreatedEventHandler : IConsumer<ReportCreated>
{
    private ILogger<PrepareReportWhenReportCreatedEventHandler> _logger;
    private IMediator _mediator;

    public PrepareReportWhenReportCreatedEventHandler(ILogger<PrepareReportWhenReportCreatedEventHandler> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public Task Consume(ConsumeContext<ReportCreated> context)
    {
        _logger.LogInformation("Starting prepare report data process");
        
        _mediator.Send(new PrepareReportCommand { ReportId = context.Message.Id });
        
        _logger.LogInformation("Process has been finished successfully");
        
        return Task.CompletedTask;
    }
}