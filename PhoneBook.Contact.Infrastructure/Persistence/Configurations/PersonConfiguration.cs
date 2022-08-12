using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Contact.Domain.Entities;

namespace PhoneBook.Contact.Infrastructure.Persistence.Configurations;

public class PersonConfiguration : BaseEntityTypeConfiguration<Person>
{
    protected override void DoConfigure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.Surname)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.Company)
            .HasMaxLength(100)
            .IsRequired();
    }
}