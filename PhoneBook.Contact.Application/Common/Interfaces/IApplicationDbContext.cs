using Microsoft.EntityFrameworkCore;
using PhoneBook.Contact.Domain.Entities;

namespace PhoneBook.Contact.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Person> Persons { get; set; }

    DbSet<Domain.Entities.Contact> Contacts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}