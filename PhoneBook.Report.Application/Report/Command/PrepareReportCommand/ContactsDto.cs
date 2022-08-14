using PhoneBook.Contact.Domain.Enums;

namespace PhoneBook.Report.Application.Report.Command.PrepareReportCommand;

public class ContactsDto
{
    public Guid PersonId { get; set; }
    public string Info { get; set; }
    public ContactInfoType InfoType { get; set; }
}