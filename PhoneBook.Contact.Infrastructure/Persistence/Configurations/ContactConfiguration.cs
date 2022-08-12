using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneBook.Contact.Infrastructure.Persistence.Configurations;

public class ContactConfiguration : BaseEntityTypeConfiguration<Domain.Entities.Contact>
{
    protected override void DoConfigure(EntityTypeBuilder<Domain.Entities.Contact> builder)
    {
        builder.Property(t => t.Info)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.InfoType)
            .IsRequired();

        builder.Property(t => t.PersonId)
            .IsRequired();
    }
}