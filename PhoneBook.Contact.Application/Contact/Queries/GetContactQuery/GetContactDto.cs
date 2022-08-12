using PhoneBook.Contact.Domain.Enums;

namespace PhoneBook.Contact.Application.Contact.Queries.GetContactQuery;

public class GetContactDto
{
    public Guid PersonId { get; set; }
    public string Info { get; set; }
    public ContactInfoType InfoType { get; set; }
}