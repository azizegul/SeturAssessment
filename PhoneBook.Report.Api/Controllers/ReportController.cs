
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Report.Application.Report.Command.CreateReport;
using PhoneBook.Report.Application.Report.Queries.GetReportQuery;
using PhoneBook.Report.Application.Report.Queries.GetReportsQuery;
using PhoneBook.Report.Domain.Entities;

namespace PhoneBook.Report.Api.Controllers;

public class ReportController : ApiControllerBase
{
    
     /// <summary>
     /// Get all reports.
     /// </summary>
     /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IList<ReportsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IList<ReportsDto>>> Get()
    {
        var reports = await Mediator.Send(new GetReportsQuery());

        if (!reports.Any())
            return NotFound();

        return reports;
    }
    
     
     /// <summary>
     /// Get Report
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReportData), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReportDto>> GetReport(string id)
    {
       var objectRegex =  new Regex("^[0-9a-fA-F]{24}$");
       if (!objectRegex.IsMatch(id))
           return BadRequest("Invalid Id.");

       var report = await Mediator.Send(new GetReportQuery(id));
        
        if (report is null)
            return NotFound();
        
        return report;
    }

     /// <summary>
     /// Create new reports.
     /// </summary>
     /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> Create()
    {
        return await Mediator.Send(new CreateReportCommand());
    }
}