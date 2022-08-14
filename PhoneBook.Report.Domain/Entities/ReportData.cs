using PhoneBook.Report.Domain.Common;

namespace PhoneBook.Report.Domain.Entities;

public class ReportData : BaseEntity
{
    public string Location { get; set; }
    public int RegisteredPersonCount { get; set; }
    public int RegisteredPersonPhoneCount { get; set; }
}