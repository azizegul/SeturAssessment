using PhoneBook.Report.Domain.Enums;

namespace PhoneBook.Report.Application.Report.Queries.GetReportsQuery;

public class ReportsDto
{
    public string Id { get; set; }
    public DateTime RequestDate { get; set; }
    public ReportStatus Status { get; set; }
    public string StatusName => Status.ToString();
}