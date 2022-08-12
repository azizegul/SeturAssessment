using PhoneBook.Contact.Domain.Common;
using PhoneBook.Contact.Domain.Enums;

namespace PhoneBook.Contact.Domain.Entities;

public class Contact:BaseEntity
{
    public Guid PersonId { get; set; }
    public ContactInfoType InfoType { get; set; }
    public string Info { get; set; }

    public virtual Person Person { get; set; }
}