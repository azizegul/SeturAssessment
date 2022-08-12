using PhoneBook.Contact.Application.Contact.Queries.GetContactQuery;

namespace PhoneBook.Contact.Application.Person.Queries.GetPersonQuery;

public class GetPersonDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Company { get; set; }

    public List<GetContactDto> Contacts { get; set; }
}